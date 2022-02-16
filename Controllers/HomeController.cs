using DomMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DomMS.Controllers
{
    /// <summary>
    // This controller control user loging, logout, home page, user registration
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Floor_ManagementContext _context; // creating a private variable of Data Contex to access databas

        public HomeController(ILogger<HomeController> logger, Floor_ManagementContext context) // this is constructor
        {
            _logger = logger;
            _context = context; // Initializing created variable
        }
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString(SessionName.name); // geting session data
            var mail = HttpContext.Session.GetString(SessionName.mail); // geting session data
            if (name==null || mail == null) // if session data not found 
            {
                return RedirectToAction("GoogleLogin","Home"); //then send to log in again
            }
            return View(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GoogleLogin()
        {
            return View();
        }
        /// <summary>
        // Using this function We register a user to our data base if previously not registered
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="imgUrl"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult RegisterGoogleUser(string mail, string imgUrl, string name)
        {
            var isAny = _context.Member.FirstOrDefault(x => x.Email == mail); //Using email, checking a user is already registered or not
            var _result = new ResultVM { IsSuccess = true };
            if (isAny == null) // if not
            {
                var idtoken = new Guid().ToString(); //Global Unique Id 
                isAny = new Member { Email = mail, ImageUrl = imgUrl, Name = name, IdToken = idtoken };
                try
                {
                    _context.Member.Add(isAny); // if not adding user to our database
                    _context.SaveChanges();
                    _result.Message = "Member Save Successful";
                }
                catch (Exception)
                {
                    _result.IsSuccess = false; // if something goes wrong in database 
                    _result.Message = "Member Save Faild";
                }
            }
            if (_result.IsSuccess) // when everything is ok then we add user info to our session(temp memory)
            {
                HttpContext.Session.SetString(SessionName.name, isAny.Name);
                HttpContext.Session.SetString(SessionName.mail, isAny.Email);                
                HttpContext.Session.SetString(SessionName.imgUrl, imgUrl);
                HttpContext.Session.SetString(SessionName.Id, isAny.MemberId.ToString());
                HttpContext.Session.SetString(SessionName.Role, "Member");

            }
            return Json(_result);
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Clear(); // when a user signout we are clearing his/her info from our session(temp memory)
            return View("GoogleLogin","Home");

        }
    }
}
