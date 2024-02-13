using VideoGameDAL.Models;
using Microsoft.AspNetCore.Mvc;
using VideoGameDAL.interfaces;
using VideoGameDAL.data;

namespace VideoGameDAL.Controllers
{
    public class VideoGameController : Controller
    {
        //IDataAccessLayer dal = new VideoGameListDAL();
        IDataAccessLayer dal;

        public VideoGameController (IDataAccessLayer indal) // allows for dependency injection
        {
            dal = indal;
        }
        public IActionResult Filter(string rating, string genre)
        {
            return View("MultGames", dal.FilterGames(rating, genre));
            
        }

        [HttpGet]//loads edit page
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                //int i = gameList.FindIndex(g => g.Id == id);
                //if (id == -1)
                //    return NotFound();
                //gameList.RemoveAt(i);
                dal.RemoveGame(id);
                TempData["Success"] = "Game Deleted";
                return RedirectToAction("MultGames", "VideoGame");
                //return View("MultGames", dal.GetGames());
            }
        }
        [HttpGet]//loads edit page
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = "Game data not found";
                return View();
            }
            else
            {
                //VideoGame? g = gameList.Where(g => g.Id == id).FirstOrDefault();
                VideoGame? g = dal.GetGame(id);
                if (g == null)
                {
                    ViewData["Error"] = "Game not found"; // cant find game with this id
                }
                return View(g);
            }
        }
        [HttpPost]//pushes edits/ saves
        public IActionResult Edit(VideoGame g)
        {
            //int i;
            //i = gameList.FindIndex(x => x.Id == g.Id);
            //gameList[i] = g;
            dal.UpdateGame(g);
            TempData["Success"] = "Game Updated";
            return RedirectToAction("MultGames", "VideoGame");
        }


        [HttpGet]
        public IActionResult Add()
        {
            // Movie m = new Movie("Shrek 2", 2004, 5, "https://tse2.mm.bing.net/th?id=OIP.eli-qDZMTCAQLfUJsGngPgAAAA&pid=Api&P=0&h=220");
            return View();
        }


        public IActionResult Collection()
        {
            //VideoGame m = new VideoGame("Tron", 1982, 4.7f, "https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220");
            return View();
        }

        [HttpPost]
        public IActionResult Add(VideoGame g)
        {
            if (g.Title == "Cats")
            {
                ModelState.AddModelError("Title", "You cannot add this game.");
            }
            if (ModelState.IsValid)
            {
                dal.AddGame(g);
                return RedirectToAction("MultGames", "VideoGame");

            }
            //else
            return View();
        }
        public IActionResult MultGames()
        {
            return View(dal.GetCollection());
        }

        [HttpPost]
        public IActionResult Loaned(int g, string name)
        {
            dal.LoanGame(g, name);
            return RedirectToAction("MultGames", "VideoGame");
        }
        [HttpPost]
        public IActionResult Return(int g)
        {
            dal.ReturnGame(g);
            return RedirectToAction("MultGames", "VideoGame");
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("MultGames", dal.GetCollection());
            }
            return View("MultGames", dal.SearchForGames(key));
        }
    }
}



