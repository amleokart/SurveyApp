using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database.DataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly SurveyAppContext _db;

        public QuestionController(SurveyAppContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            //if (questionId == null || questionId == 0) return NotFound("Not found ID ID");
            var question = _db.Questions.Find(Id);
            if (question == null) return NotFound("Not found");
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var question = _db.Questions.Find(Id);
            if (question == null) return NotFound("Not found");
            _db.Questions.Remove(question);
            _db.SaveChanges();
            return RedirectToAction("details","survey",new {Id=question.SurveyId});
        }
    }
}
