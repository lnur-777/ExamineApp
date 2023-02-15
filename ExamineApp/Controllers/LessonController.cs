using ExamineApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamineApp.Controllers
{
    public class LessonController : Controller
    {
        ExamineDbContext dbContext { get; set; }
        public LessonController()
        {
            dbContext = new();
        }
        public IActionResult Index()
        {
            var lessons = dbContext.Lessons.ToList();
            return View(lessons);
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Lesson lesson)
        {
            try
            {
                dbContext.Add(lesson);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Index", dbContext.Lessons.ToList());
        }
    }
}
