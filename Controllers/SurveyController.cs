using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database.DataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveyAppContext _db;

        public SurveyController(SurveyAppContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var surveys = _db.Surveys.ToList();
            return View(surveys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(string surveyName, string surveyDesc)
        {
            var sur = new SurveyApp.Database.Models.Survey();
            sur.Name = surveyName;
            sur.Description = surveyDesc;
            sur.UserId = 1;
            _db.Surveys.Add(sur);

            _db.SaveChanges();

            var createdSurvey = _db.Surveys.Where(s => s.Name == surveyName).First();

            return RedirectToAction("Details", "Survey", new { id = createdSurvey.Id });
        }


    }
}
