using VideoGameDAL.Models;
using VideoGameDAL_DI.Models;

namespace VideoGameDAL.interfaces
{
    public interface IDataAccessLayer
    {

        IEnumerable<VideoGame> GetCollection();
        void AddGame(VideoGame game);
        void RemoveGame(int? id);
        VideoGame? GetGame(int? id);

        void UpdateGame(VideoGame game);
        void LoanGame(int id, string name);
        void ReturnGame(int id);
        IEnumerable<VideoGame> SearchForGames(string key);
        IEnumerable<VideoGame> FilterGames(string? rating,string? genre);
        List<Genre> GetGenres();
    }
}
