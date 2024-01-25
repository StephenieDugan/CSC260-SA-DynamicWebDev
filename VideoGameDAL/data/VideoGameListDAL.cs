﻿using VideoGameDAL.interfaces;
using VideoGameDAL.Models;


namespace VideoGameDAL.data
{
    public class VideoGameListDAL : IDataAccessLayer
    {

        private static List<VideoGame> gameList = new List<VideoGame>()
        {
            new VideoGame("Diablo 4","Windows,Xbox, PlayStation 4, PlayStation 5, Steam","Action RPG, Open World","Mature" , 2023,"https://tse1.mm.bing.net/th?id=OIP.VHrPQ59f8_7TV9Q4LyGz9QHaKQ&pid=Api&P=0&h=220"),
            new VideoGame("Diablo 3","Windows,Xbox One, Xbox 360, PlayStation 4, PlayStation 3, Nintendo Switch","Action RPG, Hack and Slash","Mature" , 2012,"https://crossplaygames.b-cdn.net/wp-content/uploads/2023/04/diablo-iii_cover-768x1024.jpg"),
            new VideoGame("Ori and the Blind Forest","PC, Xbox, Nintendo Switch","Metroidvania, Platformer-adventure","Everyone", 2015,"https://tse1.mm.bing.net/th?id=OIP.JqVZIIqX8ed3QYbQt3rqZgHaJs&pid=Api&P=0&h=220"),
            new VideoGame("Sea of Thieves","Windows, Xbox One, Xbox Series X|S, Steam, Microsoft","Action, Adventure","Teen" , 2018,"https://hdqwalls.com/download/sea-of-thieves-2017-ad-2048x2048.jpg"),
            new VideoGame("Halo: The Master Chief Collection"," Xbox One, Xbox Series X|S","Action, Adventure, First Person Shooter","Mature" , 2019,"https://upload.wikimedia.org/wikipedia/en/a/a3/Halo_TMCC_KeyArt_Vert_2019.png"),

        };
        public void AddGame(VideoGame game)
        {
           gameList.Add(game);
        }
        public VideoGame? GetGame(int? id)
        {
            VideoGame? foundGame = gameList.Where(m => m.Id == id).FirstOrDefault();
            return foundGame;
        }
        public IEnumerable<VideoGame> GetCollection()
        {
            return gameList;
        }
        public void RemoveGame(int? id)
        {
            VideoGame? foundGame = GetGame(id);
            if(foundGame != null)
            {
                gameList.Remove(foundGame);
            }
        }
        public void UpdateGame(VideoGame game)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == game.Id);
            gameList[i] = game;
        }

        public void LoanGame(int id, string name)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == id);
            gameList[i].LoanDate = DateTime.Now;
            gameList[i].LoanedTo = name;
        }
        public void ReturnGame(int id)
        {
            int i;
            i = gameList.FindIndex(x => x.Id == id);
            gameList[i].LoanDate = null;
            gameList[i].LoanedTo = null;
        }



    }
}