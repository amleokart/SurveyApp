using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using SurveyApp.Database.DataAccess;
using SurveyApp.Database.Models;

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

        [HttpPost]
        public IActionResult Register(RegistrationViewModel viewModel)
        {
            var user = new SurveyApp.Database.Models.User();
            if (_db.Users.Any(x => x.Username == user.Username))
            {
                ViewBag.DuplicateMessage = "Username already exist.";
                //return View("Register", "user");
                return View(new RegistrationViewModel());
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful";
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Registration()
        {
            return View();
        }
    }

  
}
