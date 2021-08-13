using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database.DataAccess;
using SurveyApp.Database.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.Controllers
{
    public class OptionController : Controller
    {
        private readonly SurveyAppContext _db;

        public OptionController(SurveyAppContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int ?Id)
        {
            if (Id == null || Id == 0) return NotFound("Not found");
            var question = _db.Questions.FirstOrDefault(s => s.Id == Id); ;
            if (question == null) return NotFound("Not found");
            ViewBag.QuestionId = Id;
            ViewBag.SurveyId = question.SurveyId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Content,CreatedAt,LastModified,QuestionId")] Option option)
        {
            option.CreatedAt = DateTimeOffset.Now;
            option.LastModified = DateTimeOffset.Now;
            _db.Options.Add(option);
            _db.SaveChanges();
            return RedirectToAction("edit", "question", new { Id = option.QuestionId });
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) return NotFound("Not found ID");
            var option = _db.Options.Find(Id);
            if (option == null) return NotFound("Not found");
            return View(option);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var option = _db.Options.Find(Id);
            if (option == null) return NotFound("Not found");
            _db.Options.Remove(option);
            _db.SaveChanges();
            return RedirectToAction("edit", "question", new { Id = option.QuestionId });
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) return NotFound("Not found");
            var option = _db.Options.FirstOrDefault(s => s.Id == Id); ;
            if (option == null) return NotFound("Not found");
            ViewBag.questionId = option.QuestionId;
            return View(option);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Option o)
        {
            if (ModelState.IsValid)
            {
                Option option = _db.Options.FirstOrDefault(t => t.Id == o.Id);
                option.Content = o.Content;
                option.LastModified = DateTimeOffset.Now;
                _db.SaveChanges();
                return RedirectToAction("edit", "question", new { Id = o.QuestionId });
            }
            return View(o);
        }

    }
}
