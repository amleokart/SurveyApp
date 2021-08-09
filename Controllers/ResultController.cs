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
     

        public ResultController(SurveyAppContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(string code)
        {
            var survey = _db.Surveys.FirstOrDefault(s => s.Code.Equals(code));
            if (survey == null)
            {
                return NotFound("Couldn't find survey with code " + code);
            }
            else
            {
                return View(survey);
            }
                
        }

        [HttpPost]
        public IActionResult Insert(int surveyId)
        {
        
                var res = new Result()
                {
                    SurveyId=surveyId,
                    Completed=false,
                    CreatedAt=DateTimeOffset.Now

                };
                _db.Results.Add(res);
                _db.SaveChanges();
            
            

            return RedirectToAction("Edit", new { id = res.Id }) ;
        }
    }
}
