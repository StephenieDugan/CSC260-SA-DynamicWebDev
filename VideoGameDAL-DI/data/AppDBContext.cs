using Microsoft.EntityFrameworkCore;
using VideoGameDAL.Models;
namespace VideoGameDAL_DI.data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }
        //will create Games table in db using VideoGame model
        public DbSet<VideoGame> Games { get; set; }

    }
}
