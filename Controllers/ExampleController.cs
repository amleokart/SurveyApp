using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Controllers
{
    [Authorize]
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
