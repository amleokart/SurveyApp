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
            var user = _db.Users.FirstOrDefault(x => x.Username == viewModel.Username || x.Email == viewModel.Email);
            if (user != null)
            {
                ViewBag.DuplicateMessage = "Username already exist.";
                return View("Registration");
            }
            else if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                ViewBag.DuplicateMessage = "Password do not match.";
                return View("Registration");
            }
            else
            {

                user = new User()
                {
                    Username = viewModel.Username,
                    Email = viewModel.Email.ToLower(),
                };
                _db.Users.Add(user);
                _db.SaveChanges();
            }

            return RedirectToAction("Login", "Auth");
        }
       
        public IActionResult Registration()
        {
            return View();
        }
    }

  
}
