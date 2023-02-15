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
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Pupil pupil)
        {
            try
            {
                dbContext.Add(pupil);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Index", dbContext.Pupils.ToList());
        }
    }
}
