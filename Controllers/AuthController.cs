using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database.DataAccess;
using System.Data.SqlClient;
using System.Data;
using SurveyApp.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace SurveyApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly SurveyAppContext _db;

        public AuthController(SurveyAppContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(String email, String password, String returnUrl) {

            ViewData["ReturnUrl"] = returnUrl;

            var user = new SurveyApp.Database.Models.User();
            if(_db.Users.Any(x => x.Email == user.Email) && _db.Users.Any(x => x.EncryptedPassword == user.EncryptedPassword))
            //if (email == "email" && password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, email)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);


            if (string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect("/");
                } else
                {
                    return Redirect(returnUrl);
                }
            }
            TempData["Error"] = "Username or password is invalid";
            return View("login");
        }

        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet("denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
