using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationPractice.Models;

namespace ValidationPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidPractice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValidPractice(ProfileModel p)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
