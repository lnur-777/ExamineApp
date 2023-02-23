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
            return View("Index", dbContext.Pupils.ToList());
        }
    }
}
