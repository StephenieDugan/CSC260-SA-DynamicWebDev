using VideoGameDAL.Models;

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
    }
}
