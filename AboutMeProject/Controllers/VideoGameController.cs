using AboutMeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AboutMeProject.Controllers
{
    public class VideoGameController : Controller
    {
        private static List<VideoGame> gameList = new List<VideoGame>()
        {
            new VideoGame("Diablo 4","Windows,Xbox, PlayStation 4, PlayStation 5, Steam","Action RPG, Open World","Mature" , 2023,"https://tse1.mm.bing.net/th?id=OIP.VHrPQ59f8_7TV9Q4LyGz9QHaKQ&pid=Api&P=0&h=220"),
            new VideoGame("Diablo 3","Windows,Xbox One, Xbox 360, PlayStation 4, PlayStation 3, Nintendo Switch","Action RPG, Hack and Slash","Mature" , 2012,"https://crossplaygames.b-cdn.net/wp-content/uploads/2023/04/diablo-iii_cover-768x1024.jpg"),
            new VideoGame("Ori and the Blind Forest","PC, Xbox, Nintendo Switch","Metroidvania, Platformer-adventure","Everyone", 2015,"https://tse1.mm.bing.net/th?id=OIP.JqVZIIqX8ed3QYbQt3rqZgHaJs&pid=Api&P=0&h=220"),
            new VideoGame("Sea of Thieves","Windows, Xbox One, Xbox Series X|S, Steam, Microsoft","Action, Adventure","Teen" , 2018,"https://hdqwalls.com/download/sea-of-thieves-2017-ad-2048x2048.jpg"),
            new VideoGame("Halo: The Master Chief Collection"," Xbox One, Xbox Series X|S","Action, Adventure, First Person Shooter","Mature" , 2019,"https://upload.wikimedia.org/wikipedia/en/a/a3/Halo_TMCC_KeyArt_Vert_2019.png"),

        };
        [HttpGet]//loads edit page
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                int i = gameList.FindIndex(g => g.Id == id);
                if (id == -1)
                    return NotFound();
                gameList.RemoveAt(i);
                TempData["Success"] = "Game Deleted";
                return RedirectToAction("MultGames", "VideoGame");
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
                VideoGame? g = gameList.Where(g => g.Id == id).FirstOrDefault();
                if (g == null)
                {
                    ViewData["Error"] = "Game not found"; // cant find game with this id
                }
                return View(g);
            }
        }
        [HttpPost]//pushes edits
        public IActionResult Edit(VideoGame g)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == g.Id);
            gameList[i] = g;
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
            if(g.Title == "Cats")
            {
                ModelState.AddModelError("Title", "You cannot add this movie.");
            }
            if (ModelState.IsValid)
            {
                gameList.Add(g);
                return RedirectToAction("MultGames", "VideoGame");

            }
            //else
            return View();
        }
        public IActionResult MultGames()
        {
            return View(gameList);
        }
        
        [HttpPost]
        public IActionResult Loaned(int g,string name)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == g);
            gameList[i].LoanDate = DateTime.Now;
            gameList[i].LoanedTo =  name;
            return RedirectToAction("MultGames", "VideoGame");
        }
        [HttpPost]
        public IActionResult Return(int g)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == g);
            gameList[i].LoanDate = null;
            gameList[i].LoanedTo = null;
            return RedirectToAction("MultGames", "VideoGame");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}



