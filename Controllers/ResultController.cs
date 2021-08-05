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
    public class ResultController : Controller
    {
        private readonly SurveyAppContext _db;
        private object resultId;

        public ResultController(SurveyAppContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet ("create")]
        public IActionResult Create(string code)
        {
            var survey = _db.Surveys.Where(s => s.Code == code);
            return View(survey);
        }

        [HttpPost("insert")]
        public IActionResult Insert(int surveyId)
        {
            using(var context = new SurveyAppContext())
            {
                var res = new Result()
                {
                    Id=1,
                    Completed=true,

                };
                context.Results.Add(res);
                context.SaveChanges();
            }
            

            return RedirectToAction("Edit", new { id = resultId }) ;
        }
    }
}
