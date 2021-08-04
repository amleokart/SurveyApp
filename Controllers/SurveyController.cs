using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Database.DataAccess;
using SurveyApp.Database.Models;

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
            var sur = new Survey();
            sur.Name = surveyName;
            sur.Description = surveyDesc;
            sur.UserId = 1;
            _db.Surveys.Add(sur);

            _db.SaveChanges();

            return RedirectToAction("Details", "Survey", new { sur.Id });
        }

        public IActionResult Details(int id)
        {
            var survey = _db.Surveys.Include(s => s.Questions).ThenInclude(q => q.Options).FirstOrDefault(s => s.Id == id);
            if (survey == null) return NotFound("Couldnt find survey with id " + id);
            else return View(survey);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) return NotFound("Not found");
            var survey = _db.Surveys.Find(Id);
            if (survey == null) return NotFound("Not found");
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Survey s) {
            if (ModelState.IsValid){
                Survey survey = _db.Surveys.FirstOrDefault(t => t.Id == s.Id);
                survey.Name = s.Name;
                survey.Status = s.Status;
                survey.LastModified = DateTimeOffset.Now;
                _db.SaveChanges();
                return RedirectToAction("details", "survey", new { Id = s.Id });
            }
            return View(s);
        }
    }
}
