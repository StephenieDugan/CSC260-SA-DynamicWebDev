﻿using VideoGameDAL.interfaces;
using VideoGameDAL.Models;


namespace VideoGameDAL.data
{
    public class FavouriteGamesDAL : IDataAccessLayer
    {

        private static List<VideoGame> gameList = new List<VideoGame>()
        {
            new VideoGame("Bee Movie: the Game","Windows,TV","Action, Adventure","Everyone" , 2007,"https://tse2.mm.bing.net/th?id=OIP.1BrV8rJ3p7EstxMQKzcZjgHaK-&pid=Api&P=0&h=220"),
            new VideoGame("Mars needs Moms: the Game","Windows,TV","Adventure","Everyone" , 2011,"https://tse4.mm.bing.net/th?id=OIP.CeUyl-fpo8gbi628Q9l94AHaLH&pid=Api&P=0&h=220"),
            new VideoGame("The Reef: the Game","Windows,TV","Adventure","Everyone" , 2006,"https://tse1.mm.bing.net/th?id=OIP.pSLarx54OIUT9BrnX8M1hQHaJU&pid=Api&P=0&h=220"),
            new VideoGame("The Last Airbender: the Game","Windows,TV","Adventure, Teens","Everyone" , 2010,"https://tse2.mm.bing.net/th?id=OIP.eA2YXWYTzZ6MziEt0WCWOwHaKj&pid=Api&P=0&h=220"),
            new VideoGame("Emoji Movie: the Game","Windows,TV","Teens","Everyone" , 2017,"https://tse4.mm.bing.net/th?id=OIP.ti__I1yHcR8tgorgT8fuCwHaJ_&pid=Api&P=0&h=220"),


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
        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            return gameList.Where(x => x.Title.ToLower().Contains(key.ToLower()));
        }

        public void RemoveGame(int? id)
        {
            VideoGame? foundGame = GetGame(id);
            if (foundGame != null)
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