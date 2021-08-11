using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Database.DataAccess;

namespace SurveyApp.Controllers
{
    public class UserController : Controller
    {

        private readonly SurveyAppContext _db;

        public UserController(SurveyAppContext db)
        {
            _db = db;
        }

        [HttpGet("registration")]
        public IActionResult Registration(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet("denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password)
        {
            var user = new SurveyApp.Database.Models.User();
            user.Username = username;
            user.Email = email;
            user.EncryptedPassword = password;
            _db.Users.Add(user);
            _db.SaveChanges();
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
