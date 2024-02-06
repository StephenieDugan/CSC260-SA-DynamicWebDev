using VideoGameDAL.interfaces;
using VideoGameDAL.data;
using Microsoft.EntityFrameworkCore;
using VideoGameDAL_DI.data;
namespace VideoGameDAL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //send in DAL as dependency
            //transient = creates new object each time service is requested
            //scoped = instances are created  once per request, on refresh you get new instance
            //singleton = always return the same object instance
            builder.Services.AddTransient<IDataAccessLayer, VideoGameListDAL>();
            //builder.Services.AddTransient<IDataAccessLayer, FavouriteGamesDAL>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}