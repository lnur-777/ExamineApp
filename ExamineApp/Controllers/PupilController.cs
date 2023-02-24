using ExamineApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamineApp.Controllers
{
    public class PupilController : Controller
    {
        ExamineDbContext dbContext { get; set; }
        public PupilController()
        {
            dbContext = new();
        }
        public IActionResult Index()
        {
            var pupils = dbContext.Pupils.ToList();
            return View(pupils);
        }

        public IActionResult Registration()
        {
            ViewBag.AllClasses = dbContext.Classs.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Pupil pupil)
        {
            dbContext.Add(pupil);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.AllClasses = dbContext.Classs.ToList();
            var pupil = dbContext.Pupils.FirstOrDefault(x => x.Id == id);
            return View(pupil);
        }

        [HttpPost]
        public IActionResult Update(Pupil pupil)
        {
            dbContext.Update(pupil);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pupil = dbContext.Pupils.FirstOrDefault(x => x.Id == id);
            dbContext.Remove(pupil);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
