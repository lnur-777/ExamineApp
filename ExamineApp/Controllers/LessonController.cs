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
            var classesInDb = dbContext.Classs.ToList();
            var isClassExistInDb = classesInDb.Where(x => x.ClassNum == lesson.ClassNum).ToList().Count > 0;
            if (!isClassExistInDb)
            {
                Class cls = new() { ClassNum = lesson.ClassNum };
                dbContext.Add(cls);
            }
            dbContext.Add(lesson);
            dbContext.SaveChanges();
            return View("Index", dbContext.Lessons.ToList());
        }
    }
}
