using Microsoft.EntityFrameworkCore;
using VideoGameDAL.Models;
using VideoGameDAL_DI.Models;
namespace VideoGameDAL_DI.data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }
        //will create Games table in db using VideoGame model
        public DbSet<VideoGame> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
