using DomMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomMS.Controllers
{
    /// <summary>
    /// This is Admin controller. All the adminstrative work is controled by this controller
    /// </summary>
    public class AdminController : Controller
    {
        private readonly Floor_ManagementContext _context;

        /// <summary>
        /// This is constructor for this controller. 
        /// </summary>
        /// <param name="context"></param>
        public AdminController(Floor_ManagementContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// this method used to login as a Admin.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>True or Flase based on user input</returns>
        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            if(email != "" && password != "")
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);//Searching in database if the admin's email and password is currect
                if(user != null) // if found a admin
                {
                    HttpContext.Session.SetString(SessionName.name, user.Email); // storing info in session
                    HttpContext.Session.SetString(SessionName.mail, user.Email);
                    HttpContext.Session.SetString(SessionName.Id, user.UserId.ToString());
                    HttpContext.Session.SetString(SessionName.Role, "Admin"); // storing info in session
                    return Json(true);
                }
            }            
            return Json(false);
        }

        public JsonResult Logout()
        {
            HttpContext.Session.Clear();// clearing session when a user logout
            return Json("");
        }
        [HttpGet]
        public IActionResult RoomSetup()
        {
            ViewBag.IsSaved = -1;
            return View();
        }

        /// <summary>
        // Creating a new room 
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RoomSetup(Room room)
        {
            var name = HttpContext.Session.GetString(SessionName.name); // geting session data which are stored login time
            var mail = HttpContext.Session.GetString(SessionName.mail);// geting session data which are stored login time
            var role = HttpContext.Session.GetString(SessionName.Role);// geting session data which are stored login time
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.IsSaved = -1;
            room.EntryDate = DateTime.Now;

            _context.Room.Add(room); //adding new room to save in database
            try
            {
                _context.SaveChanges(); // trying to save that room
                ViewBag.IsSaved = 1;// if saved then returning 1
            }
            catch (Exception)
            {
                ViewBag.IsSaved = 0; // if not then 0
            }
            return View();
        }

        /// <summary>
        // To show roomList to admin. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RoomList()
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var role = HttpContext.Session.GetString(SessionName.Role);
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Admin");
            }
            var roomList = _context.Room.ToList(); // fetching data from the database
            return View(roomList);
        }

        /// <summary>
        // based on roomId, a room info is shown to edit 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditRoom(long id)
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var role = HttpContext.Session.GetString(SessionName.Role);
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.edit = -1;
            var room = _context.Room.FirstOrDefault(x => x.RoomId == id);
            if (room == null) return RedirectToAction("RoomList");
            return View(room);
        }
        
        /// <summary>
        // This method is called when a room is changed or updated any value
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            var name = HttpContext.Session.GetString(SessionName.name);// geting session data which are stored login time
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var role = HttpContext.Session.GetString(SessionName.Role);// geting session data which are stored login time
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Admin");
            }
            var c = _context.Room.Any(x => x.RoomId == room.RoomId); // based on roomId, checking this room is already exist or not
            if (!c) return RedirectToAction("RoomList"); // if not exist, redirecting to RoomList
            _context.Room.Update(room); // if exist then updating value
            try
            {
                _context.SaveChanges(); // saving on the database
                ViewBag.edit = 1; // if saved then return 1
            }
            catch (Exception)
            {
                ViewBag.edit = 0; //if not saved then 0
            }
            return View(room);
        }
        /// <summary>
        // based on roomId, a room is deleted  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DeleteRoom(long id)
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var role = HttpContext.Session.GetString(SessionName.Role);
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return Json("Session out");
            }
            var room = _context.Room.FirstOrDefault(x => x.RoomId == id); // searching for the room in database
            if (room == null) return Json(false); // not found then return false
            _context.Room.Remove(room); // found then ready to remove it
            try
            {
                _context.SaveChanges(); // trying remove from the database
            }
            catch (Exception)
            {
                return Json(false); // if faild to remove retunr false
            }
            return Json(true); // otherwise return true
        }

        /// <summary>
        // room bookings chart for admin based on a date(for a single day)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public JsonResult LoadGantt(DateTime date)
        {
            var name = HttpContext.Session.GetString(SessionName.name);
            var mail = HttpContext.Session.GetString(SessionName.mail);
            var role = HttpContext.Session.GetString(SessionName.Role);
            if (name == null || mail == null || role == null || role != "Admin")
            {
                return Json("Session out");
            }
            var dataList = _context.Bookings.Where(x => x.FromDate == date) //for a day, fetching data and formating it to show
                                            .Select(x => new
                                            {
                                                recordID = x.BookingId.ToString(),
                                                row = x.Room != null ? x.Room.Name : "",
                                                tooltip = x.FromTime.ToString().Substring(0, 5) + " - " + x.ToTime.ToString().Substring(0, 5),
                                                start = x.FromDate.Value.ToString("MMM dd yyyy ") + x.FromTime.ToString().Substring(0,8),
                                                end = x.FromDate.Value.ToString("MMM dd yyyy ") + x.ToTime.ToString().Substring(0, 8),
                                                group = "Room Reservation List Of " + x.FromDate.Value.ToString("dddd MMM dd, yyyy"),
                                                groupId = "1",
                                                subGroupId = x.Room != null && x.Room.IsKitchen == false ? "1" : "2",
                                                subGroup = x.Room != null && x.Room.IsKitchen == false ? "ROOM" : "Kitchen"
                                            }).ToList(); // making a list to show on view

            return Json(dataList);
        }

}
}
