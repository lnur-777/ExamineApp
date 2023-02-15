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
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Examine examine)
        {
            try
            {
                dbContext.Add(examine);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Index", dbContext.Examines.ToList());
        }
    }
}
