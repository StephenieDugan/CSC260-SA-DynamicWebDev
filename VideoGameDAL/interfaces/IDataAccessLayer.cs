using VideoGameDAL.Models;

namespace VideoGameDAL.interfaces
{
    public interface IDataAccessLayer
    {

        IEnumerable<VideoGame> GetGames();
        void AddGame(VideoGame game);
        void RemoveGame(int id);
        VideoGame GetGame(int? id);


    }
}
