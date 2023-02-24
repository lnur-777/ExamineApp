using ExamineApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var lesson = dbContext.Lessons.FirstOrDefault(x => x.Id == id);
            return View(lesson);
        }

        [HttpPost]
        public IActionResult Update(Lesson lesson)
        {
            dbContext.Update(lesson);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var lesson = dbContext.Lessons.FirstOrDefault(x => x.Id == id);
            dbContext.Remove(lesson);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
