using System.Reflection;
using Catblog.Controllers.Accounts;
using Catblog.Data;
using Catblog.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Catblog.Dto;
using Catblog.ServiceInterface;
using Catblog.Services;

namespace Catblog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<CatblogDb>(options =>
	        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPostServices, PostServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();

			builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = string.Empty;

                opt.Password.RequiredLength = 0; // Set to 8
                opt.Password.RequireDigit = false; // Set to True
                opt.Password.RequireUppercase = false; // Set to True
                opt.Password.RequireLowercase = false; // Set to True
                opt.Password.RequireNonAlphanumeric = false; // Set to True
            }).AddEntityFrameworkStores<CatblogDb>()
            .AddDefaultTokenProviders();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
