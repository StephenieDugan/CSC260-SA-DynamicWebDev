using AboutMeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace AboutMeProject.Controllers
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
        public IActionResult AboutMe()
        {
            
            return View();
        }

        public IActionResult Past()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }
        public IActionResult MadLibs()
        { 
            ViewData["Title"] = "MadLibs Form";

            return View();
        }
       
        public IActionResult MadlibsOutput(string Adj1, string Nat1, string Pers1,string Noun1, string Adj2, string Noun2, string Adj3, string Adj4, string Noun3, string Noun4, string Num1, string Sha1, string food1, string food2, string Num2)
        {
            ViewData["Title"] = "MadlibsOutput Form";
            ViewBag.Adj1 = Adj1;
            ViewBag.Nat1 = Nat1;
            ViewBag.Pers1 = Pers1;
            ViewBag.Noun1 = Noun1;
            ViewBag.Adj2 = Adj2;
            ViewBag.Noun2 = Noun2;
            ViewBag.Adj3 = Adj3;
            ViewBag.Adj4 = Adj4;
            ViewBag.Noun3 = Noun3;
            ViewBag.Noun4 = Noun4;
            ViewBag.Num1 = Num1;
            ViewBag.Sha1 = Sha1;
            ViewBag.food1 = food1;
            ViewBag.food2 = food2;
            ViewBag.Num2 = Num2;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
