using ExamineApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamineApp.Controllers
{
    public class ExamineController : Controller
    {
        ExamineDbContext dbContext { get; set; }
        public ExamineController()
        {
            dbContext = new();
        }
        public IActionResult Index()
        {
            var examines = dbContext.Examines.ToList();
            return View(examines);
        }

        public IActionResult Registration()
        {
            ViewBag.AllLessons = dbContext.Lessons.ToList();
            ViewBag.AllPupils = dbContext.Pupils.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Examine examine)
        {
            dbContext.Add(examine);
            dbContext.SaveChanges();
            return View("Index", dbContext.Examines.ToList());
        }
    }
}
