using Microsoft.EntityFrameworkCore;
using TribunalDePoche.Data;

namespace TribunalDePoche
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Configure MySQL Database
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 28))));

            // Add services for Razor Pages
            builder.Services.AddRazorPages();

            // Configure other services like authentication, etc. (optional)
            // builder.Services.AddAuthentication(...);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable authentication (if configured)
            // app.UseAuthentication();

            app.UseAuthorization();

            // Map Razor Pages
            app.MapRazorPages();

            app.Run();
        }
    }
}
