﻿using AboutMeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AboutMeProject.Controllers
{
    public class VideoGameController : Controller
    {
        private static List<VideoGame> gameList = new List<VideoGame>()
        {
            new VideoGame("A Series of Unfortunate Events", 2004, 4.0f,"https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220"),
            new VideoGame("Everything Everywhere All at Once", 2022, 4.5f,"https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220"),
            new VideoGame("Spider-Man Across the Spider-Verse", 2023, 5f,"https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220"),
            new VideoGame("How to Train Your Dragon: Lost World", 2010, 5f,"https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220")
        };

        [HttpGet]
        public IActionResult Add()
        {
            // Movie m = new Movie("Shrek 2", 2004, 5, "https://tse2.mm.bing.net/th?id=OIP.eli-qDZMTCAQLfUJsGngPgAAAA&pid=Api&P=0&h=220");
            return View();
        }


        public IActionResult Collection()
        {
            VideoGame m = new VideoGame("Tron", 1982, 4.7f, "https://tse2.mm.bing.net/th?id=OIP.BUuP7rMyLxN0pXmhNQxapAHaHa&pid=Api&P=0&h=220");
            return View(m);
        }
        [HttpPost]
        public IActionResult Add(VideoGame g)
        {
            gameList.Add(g);
            return RedirectToAction("MultGames", "VideoGame");
            //return View();
        }
        public IActionResult MultGames()
        {
            return View(gameList);
        }
        public IActionResult Loaned(int ID)
        {
            var oneGame = gameList.Find(x => x.Id == ID);
            oneGame.ReleaseDate = DateTime.Now;
            return View(gameList);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}



