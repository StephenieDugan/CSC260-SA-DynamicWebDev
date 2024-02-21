using System.Xml.Linq;
using VideoGameDAL.interfaces;
using VideoGameDAL.Models;
using VideoGameDAL_DI.data;
using VideoGameDAL_DI.Models;


namespace VideoGameDAL.data
{
    public class FavouriteGamesDAL : IDataAccessLayer
    {
        private AppDBContext db;
        public FavouriteGamesDAL(AppDBContext indb)
        {
            db = indb;
        }
        //private static List<VideoGame> gameList = new List<VideoGame>()
        //{
        //    new VideoGame("Bee Movie: the Game","Windows,TV","Action, Adventure","Everyone" , 2007,"https://tse2.mm.bing.net/th?id=OIP.1BrV8rJ3p7EstxMQKzcZjgHaK-&pid=Api&P=0&h=220"),
        //    new VideoGame("Mars needs Moms: the Game","Windows,TV","Adventure","Everyone" , 2011,"https://tse4.mm.bing.net/th?id=OIP.CeUyl-fpo8gbi628Q9l94AHaLH&pid=Api&P=0&h=220"),
        //    new VideoGame("The Reef: the Game","Windows,TV","Adventure","Everyone" , 2006,"https://tse1.mm.bing.net/th?id=OIP.pSLarx54OIUT9BrnX8M1hQHaJU&pid=Api&P=0&h=220"),
        //    new VideoGame("The Last Airbender: the Game","Windows,TV","Adventure, Teens","Everyone" , 2010,"https://tse2.mm.bing.net/th?id=OIP.eA2YXWYTzZ6MziEt0WCWOwHaKj&pid=Api&P=0&h=220"),
        //    new VideoGame("Emoji Movie: the Game","Windows,TV","Teens","Everyone" , 2017,"https://tse4.mm.bing.net/th?id=OIP.ti__I1yHcR8tgorgT8fuCwHaJ_&pid=Api&P=0&h=220"),


        //};
        public void AddGame(VideoGame game)
        {
            db.Games.Add(game);
            db.SaveChanges();
        }
        public VideoGame? GetGame(int? id)
        {
            VideoGame? foundGame = db.Games.Where(m => m.Id == id).FirstOrDefault(); //.....id.Include(m => m.Genre).First.......
            return foundGame;
        }
        public IEnumerable<VideoGame> GetCollection()
        {
            return db.Games;//.....Games.Include(m => m.Genre).ToList();.......
        }
        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            return db.Games.Where(x => x.Title.ToLower().Contains(key.ToLower()));
        }

        public void RemoveGame(int? id)
        {
            VideoGame? foundGame = GetGame(id);
            if (foundGame != null)
            {
                db.Games.Remove(foundGame);
            }
        }
        public void UpdateGame(VideoGame game)
        {
            //int i;
            //i = gameList.FindIndex(x => x.Id == game.Id);
            //gameList[i] = game;
            db.Update(game);
            db.SaveChanges();
        }

        public void LoanGame(int id, string name)
        {
            
            VideoGame? foundGame = db.Games.Where(m => m.Id == id).FirstOrDefault();
            if (foundGame != null)
            {
                foundGame.LoanDate = DateTime.Now;
                foundGame.LoanedTo = name;
                db.Games.Update(foundGame);
            }

            db.SaveChanges();
        }
        public void ReturnGame(int id)
        {
          
            VideoGame? foundGame = db.Games.Where(m => m.Id == id).FirstOrDefault();
            if (foundGame != null)
            {
                foundGame.LoanDate = null;
                foundGame.LoanedTo = null;
                db.Update(foundGame);
            }
            db.SaveChanges();

        }

        public IEnumerable<VideoGame> FilterGames(string? rating, string? genre)
        {
            if (genre == null)
                genre = string.Empty;
            if (rating == null)
                rating = string.Empty;

            if (genre == "" && rating == string.Empty)
            {
                return GetCollection();
            }

            IEnumerable<VideoGame> listGamesbyGenre = GetCollection().Where(m => (!string.IsNullOrEmpty(m.Genre) && m.Genre.ToLower().Contains(genre.ToLower()))).ToList();
            IEnumerable<VideoGame> listGamesbyRating = listGamesbyGenre.Where(m => (!string.IsNullOrEmpty(m.Rating) && m.Rating.ToLower().Contains(rating.ToLower()))).ToList();

            if (listGamesbyRating.Count() == 0)
                return listGamesbyGenre;

            return listGamesbyRating;



        }

        public List<Genre> GetGenres()
        {
            return db.Genres.ToList(); 
        }
    }
}
