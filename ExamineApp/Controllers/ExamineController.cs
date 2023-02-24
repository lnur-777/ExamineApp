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
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.AllLessons = dbContext.Lessons.ToList();
            ViewBag.AllPupils = dbContext.Pupils.ToList();
            var examine = dbContext.Examines.FirstOrDefault(x => x.Id == id);
            return View(examine);
        }

        [HttpPost]
        public IActionResult Update(Examine examine)
        {
            dbContext.Update(examine);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var examine = dbContext.Examines.FirstOrDefault(x => x.Id == id);
            dbContext.Remove(examine);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
