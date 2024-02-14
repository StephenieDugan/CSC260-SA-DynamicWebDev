using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameScafoldingID.Models;
namespace VideoGameScafoldingID.data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }
        //will create Games table in db using VideoGame model
        public DbSet<VideoGame> Games { get; set; }

    }
}
