using DomMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly Floor_ManagementContext _context;

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
            ViewBag.IsValid = true;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if(email != "" && password != "")
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if(user != null)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.IsValid = false;
            return View();
        }

        [HttpGet]
        public IActionResult RoomSetup()
        {
            ViewBag.IsSaved = -1;
            return View();
        }

        [HttpPost]
        public IActionResult RoomSetup(Room room)
        {
            ViewBag.IsSaved = -1;
            room.EntryDate = DateTime.Now;

            _context.Room.Add(room);
            try
            {
                _context.SaveChanges();
                ViewBag.IsSaved = 1;
            }
            catch (Exception)
            {
                ViewBag.IsSaved = 0;
            }
            return View();
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            ViewBag.LoginUser = "admin";
            var roomList = _context.Room.ToList();
            return View(roomList);
        }

        [HttpGet]
        public IActionResult EditRoom(long id)
        {
            ViewBag.edit = -1;
            var room = _context.Room.FirstOrDefault(x => x.RoomId == id);
            if (room == null) return RedirectToAction("RoomList");
            return View(room);
        }
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            var c = _context.Room.Any(x => x.RoomId == room.RoomId);
            if (!c) return RedirectToAction("RoomList");
            _context.Room.Update(room);
            try
            {
                _context.SaveChanges();
                ViewBag.edit = 1;
            }
            catch (Exception)
            {
                ViewBag.edit = 1;
            }
            return View(room);
        }
        [HttpGet]
        public JsonResult DeleteRoom(long id)
        {
            var room = _context.Room.FirstOrDefault(x => x.RoomId == id);
            if (room == null) return Json(false);
            _context.Room.Remove(room);
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


    }
}
