using DomMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomMS.Controllers
{
    public class MemberController : Controller
    {
        private readonly Floor_ManagementContext _context;
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

        public MemberController(Floor_ManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadRoom(DateTime startDate, int duration)
        {
            var newDate = startDate.AddMinutes(duration);

            var BookedRoomList = _context.Bookings.Where(x => x.FromDate >= startDate.Date && x.FromTime >= startDate.TimeOfDay && x.ToDate >= newDate.Date && x.ToTime >= newDate.TimeOfDay).Select(x => new { roomId = x.RoomId }).Distinct().ToList();

            var roomList = _context.Room.Select(x=> new RoomVM{
                RoomId = x.RoomId,
                RoomName = x.Name,
                IsFree = true
            }).ToList();

            foreach(var room in roomList){
                var a = new{roomId = room.RoomId};
                if(BookedRoomList.Contains(a)){
                    room.IsFree = false;
                }
            }
            return Json(roomList);
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            ViewBag.LoginUser = "admin";
            var roomList = _context.Room.ToList();
            return View("RoomList", roomList);
        }

        public JsonResult Reserve(ReservationVM reservation){
            var reserve = new Bookings{
                RoomId = reservation.roomId,
                MemberId = 1,
                FromDate = reservation.date.Date,
                FromTime = reservation.date.TimeOfDay,
                ToTime = reservation.date.AddMinutes(reservation.duration).TimeOfDay,
                ToDate = reservation.date.Date,
                EntryDate = DateTime.Now
            };
            _context.Bookings.Add(reserve);
            try{
                _context.SaveChanges();
                return Json(true);    
            }
            catch(Exception){
                return Json(false);
            }
        }
    }
}
