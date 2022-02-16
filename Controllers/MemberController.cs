using DomMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomMS.Controllers
{
    /// <summary>
    // this controller control a member. what he can see or do.
    /// </summary>
    public class MemberController : Controller
    {
        private readonly Floor_ManagementContext _context;// creating a private variable of Data Contex to access databas
        private readonly IConfiguration _Configuration; 
        private readonly IMailService _mailService;// creating a private variable of Mail service to send mail

         /// <summary>
        // This is a model to show a room info
        /// </summary>
        private class RoomVM{
            public long RoomId { get; set; }
            public string RoomName { get; set; }
            public bool IsFree { get; set; }
        }
        public class ReservationVM{
            public string name { get; set; }
            public DateTime date { get; set; }
            public int  duration { get; set; }
            public long  roomId { get; set; }
            public string repeated {get; set; }
        }

        public MemberController(Floor_ManagementContext context, IConfiguration configuration, IMailService mailService) // this is constructor
        {
            _context = context;// Initializing created variable
            _Configuration = configuration;
            _mailService = mailService;// Initializing created variable
        }
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString(SessionName.name); // geting session data
            var mail = HttpContext.Session.GetString(SessionName.mail);// geting session data
            var imgUrl = HttpContext.Session.GetString(SessionName.imgUrl);// geting session data
            var memberId = Convert.ToInt64(HttpContext.Session.GetString(SessionName.Id));
            if (name == null || mail == null) // if session data not found 
            {
                return RedirectToAction("GoogleLogin", "Home");  //then send to log in again
            }
            ViewData["name"] = name; 
            ViewData["mail"] = mail;
            ViewData["imgUrl"] = imgUrl;
            var toDay = DateTime.Now;
            var bookingsList = _context.Bookings.Where(x => x.MemberId == memberId)
                                                .Select(x=> new BookingsVM
                                                {
                                                    BookingId = x.BookingId,
                                                    RoomName = x.Room != null ? x.Room.Name : "",
                                                    Date = x.FromDate.Value.ToString("MMM dd, yyyy"),
                                                    TimeDuration = x.FromTime.ToString().Substring(0,5) + " - "  + x.ToTime.ToString    ().Substring(0, 5)
                                                })
                                                .ToList(); // Geting user's previous information of booking
            return View(bookingsList);
        }
        public IActionResult Reservation()
        {
            var name = HttpContext.Session.GetString(SessionName.name);// geting session data
            var mail = HttpContext.Session.GetString(SessionName.mail);// geting session data
            if (name == null || mail == null) // if session data not found
            {
                return RedirectToAction("GoogleLogin", "Home"); //then send to log in again
            }
            ViewData["FirstName"] = name != null ? name.Split(' ')[0] : "No Name"; /// Spliting a user's name into First Name and Last Name
            ViewData["LastName"] = name != null ?  name.Split(' ')[1] : "No Name";
            return View();
        }
        /// <summary>
        // this method is called when a member select a date and a duration
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="duration"></param>
        /// <param name="reservationType"></param>
        // <returns> returns number of room list</returns>
        [HttpPost]
        public JsonResult LoadRoom(DateTime startDate, int duration, string reservationType)
        {
            var newDate = startDate.AddMinutes(duration);
            List<long> BookedRoomList = new List<long>();

            if (reservationType == "Repeated") // if a reservation is repeated 
            {
                BookedRoomList = NotFreeRoomForRepeatedReserve(startDate, newDate); //then go to this function and get booked  Room List
            }
            else // if a reservation is repeated 
            {
                BookedRoomList = _context.Bookings
                                        .Where(x => x.FromDate == startDate.Date &&
                                        ((x.FromTime >= startDate.TimeOfDay && x.FromTime <= newDate.TimeOfDay)
                                        || (x.ToTime >= startDate.TimeOfDay && x.ToTime <= newDate.TimeOfDay)
                                        || (x.FromTime > startDate.TimeOfDay && x.ToTime < newDate.TimeOfDay)
                                        || (x.FromTime < startDate.TimeOfDay && x.ToTime > newDate.TimeOfDay)
                                        )).Select(X => X.RoomId).Distinct().ToList();// looking for room id list where a room is booked for other user within given time 
            }



            var roomList = _context.Room.Select(x=> new RoomVM{
                RoomId = x.RoomId,
                RoomName = x.Name,
                IsFree = true
            }).ToList(); //making list of rooms and first making all room free

            foreach(var room in roomList){
                var a = room.RoomId;
                if(BookedRoomList.Contains(a)){
                    room.IsFree = false; // when a rooom is found booked then making it not free
                }
            }
            return Json(roomList);
        }

        /// <summary>
        // this method is for member . then can see a room list by this
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RoomList()
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            if (name == null || mail == null)
            {
                return RedirectToAction("GoogleLogin", "Home");
            }
            var roomList = _context.Room.ToList();
            return View("RoomList", roomList);
        }

        /// <summary>
        // For any kind of reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task<JsonResult> Reserve(ReservationVM reservation)
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var memberId = Convert.ToInt64(HttpContext.Session.GetString(SessionName.Id));
            if (name == null || mail == null || memberId <= 0)
            {
                return Json("Session Out");
            }
            #region For Repeated Reservation

            if (reservation.repeated == "Repeated")
            {
                DateTime todate = reservation.date.AddMonths(4).AddMinutes(reservation.duration);/// researving a room for 4 months
                bool isOk = RepeatedReservation(reservation.date, todate, reservation.roomId); // for repeated reservation calling this function
                //Sending Email for Repeated reservation start
                try
                {
                    var mailReq = new MailRequest
                    {
                        ToEmail = mail, // the mail address which he/she used to login 
                        Subject = "Reservation Confirm at Haileybury Wellbeing Centre", // email subject
                        Body = "Hello " + name + ", " + "We are happy to say Your reservation is completed successfully. You booked " + reservation.date.ToString("dddd") + " for time: " + reservation.date.ToShortTimeString().Substring(0, 5) + " to " + todate.ToShortTimeString().Substring(0, 5) + ". Thank You"

                    };
                    await _mailService.SendEmailAsync(mailReq);
                }
                catch (Exception) { }
                //Sending Email for Repeated reservation end

                return Json(isOk);
            }
            #endregion

            #region For Regular Reservation

            var reserve = new Bookings /// making a Bookings using given info
            {
                RoomId = reservation.roomId,
                MemberId = memberId,
                FromDate = reservation.date.Date,
                FromTime = reservation.date.TimeOfDay,
                ToTime = reservation.date.AddMinutes(reservation.duration).TimeOfDay,
                ToDate = reservation.date.Date,
                EntryDate = DateTime.Now
            };
            _context.Bookings.Add(reserve);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(false);
            }

            //Sending Email for Regular reservation start
            try
            {
                var mailReq = new MailRequest
                {
                    ToEmail = mail,
                    Subject = "Reservation Confirm at Haileybury Wellbeing Centre",
                    Body = "Hello " + name + ", " + "We are happy to say Your reservation is completed successfully. You booked " + reservation.date.ToString("MMM dd, yyyy") + " for time: " + reservation.date.ToShortTimeString().Substring(0, 5) + " to " + reserve.ToTime.ToString().Substring(0, 5) + ". Thank You"

                };
                await _mailService.SendEmailAsync(mailReq);
            }
            catch (Exception)
            {

            }
            //Sending Email for Regular reservation End
            return Json(true); 
            #endregion
        }

        private List<long> NotFreeRoomForRepeatedReserve(DateTime start, DateTime end)
        {
            end = end.AddMonths(6); 
            string query = "EXEC sp_NotFreeRoom4RepeatedBookings @FromDate='" + start.ToShortDateString() + "', @Todate='" + end.ToShortDateString() + "', @FROMTIME= '" + start.TimeOfDay + "', @TOTIME='" + end.TimeOfDay +"'"; /// Query Store Procedure which will give us a booked room Id
            List<long> roomId = new List<long>();

            using (var sqlConnection = new SqlConnection(_Configuration.GetConnectionString("Default")))// getting connections info
            {
                using (var cmd = new SqlCommand() // creating Sql Command to execute our SP(Store Procedure)
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = sqlConnection,
                    CommandTimeout = 900
                })
                {
                    sqlConnection.Open(); // opening the connection with database
                    using(var reader = cmd.ExecuteReader())// executing command on database
                    {
                        while (reader.Read())//if data found then read it
                        {
                            long id = Convert.ToInt64(reader["RoomId"]);
                            roomId.Add(id);
                        }
                    }
                    sqlConnection.Close(); /// work done. now closing the connection
                }
            }
            return roomId;
        }


        /// <summary>
        // Repeated Reservation is done by this function
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bookedRoomId"></param>
        /// <returns></returns>
        private bool RepeatedReservation(DateTime start, DateTime end, long bookedRoomId)
        {
            long memberId = Convert.ToInt64(HttpContext.Session.GetString(SessionName.Id));
                   

            string query = "EXEC sp_InsertRepeatedBookings @FromDate='" + start.ToShortDateString() + "', @Todate='" + end.ToShortDateString() + "', @FROMTIME= '" + start.TimeOfDay + "', @TOTIME='" + end.TimeOfDay + "', @MemberId ="+ memberId + ", @RoomId = " + bookedRoomId.ToString(); // Query for Store Procedure which will give us a booked room Id
            List<long> roomId = new List<long>();

            using (var sqlConnection = new SqlConnection(_Configuration.GetConnectionString("Default")))
            {
                using (var cmd = new SqlCommand()
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = sqlConnection,
                    CommandTimeout = 900
                })
                {
                    sqlConnection.Open();
                    int row = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        // When a user want to delete a booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteBooking(long id)
        {
            var Bookings = _context.Bookings.FirstOrDefault(x => x.BookingId == id);
            if (Bookings == null) return Json(false);
            _context.Bookings.Remove(Bookings);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }

        /// <summary>
        // Algorithm For Room Suggestion
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public JsonResult FreeRoomSuggestion(DateTime startDate, int duration)
        {
            var endDate = startDate.AddMonths(6).AddMinutes(duration);
            var roomIdList = _context.Room.Select(x => x.RoomId).ToList();
            List<FreeRoomSuggestionVM> freeRoomSuggestions = new List<FreeRoomSuggestionVM>();
            List<double> weekDay = new List<double> { 0, 1, -1, 2, -2, 3, -3 };
            List<double> minutesHour = new List<double> { 30, -30, 60, -60, 90, -90, 120, -120, 150, -150, 180, -180 };

            ///Same time but other day free room suggestion started
            #region SameTimeButOtherDay
            foreach (var day in weekDay)
            {
                var newStartDate = startDate.AddDays(day);
                var newEndDate = endDate.AddDays(day);
                List<long> bookedRoomList = NotFreeRoomForRepeatedReserve(newStartDate, newEndDate);
                var result = roomIdList.Where(r => !bookedRoomList.Any(b => b == r));
                if (result != null)
                {
                    var freeRoom = new FreeRoomSuggestionVM
                    {
                        FromDate = newStartDate.ToString("dddd MMM dd, yyyy"),
                        ToDate = newEndDate.ToString("dddd MMM dd, yyyy"),
                        FromTime = newStartDate.ToString("t"),
                        ToTime = newEndDate.ToString("t"),
                        RoomName = result.Count().ToString() + " room available"
                    };
                    freeRoomSuggestions.Add(freeRoom);
                }
                if (freeRoomSuggestions.Count() >= 3) break;
            }
            #endregion
            ///Same time but other day free room suggestion ended

            ///Same Day but Other time free room suggestion started
            #region SamedayButOtherTime
            foreach(var minuts in minutesHour)
            {
                var newStartDate = startDate.AddMinutes(minuts);
                var newEndDate = endDate.AddMinutes(minuts);
                List<long> bookedRoomList = NotFreeRoomForRepeatedReserve(newStartDate, newEndDate);
                var result = roomIdList.Where(r => !bookedRoomList.Any(b => b == r));
                if (result != null)
                {
                    var freeRoom = new FreeRoomSuggestionVM
                    {
                        FromDate = newStartDate.ToString("ddd MMM dd, yyyy"),
                        ToDate = newEndDate.ToString("ddd MMM dd, yyyy"),
                        FromTime = newStartDate.ToString("t"),
                        ToTime = newEndDate.ToString("t"),
                        RoomName = result.Count().ToString() + " room available"
                    };
                    freeRoomSuggestions.Add(freeRoom);
                }
                if (freeRoomSuggestions.Count() >= 5) break;
            }
            #endregion
            ///Same Day but Other time free room suggestion end

            return Json(freeRoomSuggestions);
        }
    }
}
