using System.Reflection;
using Catblog.Controllers.Accounts;
using Catblog.Data;
using Catblog.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Catblog.Data;
using Microsoft.AspNetCore.Identity;
using Catblog.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Azure;

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

			builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = string.Empty;

                opt.Password.RequiredLength = 0; // Set to 10
                opt.Password.RequireDigit = false; // Set to True
                opt.Password.RequireUppercase = false; // Set to True
                opt.Password.RequireLowercase = false; // Set to True
                opt.Password.RequireNonAlphanumeric = false; // Set to True
            }).AddEntityFrameworkStores<CatblogDb>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "rememberMeCookie";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                    options.SlidingExpiration = true;
                });
            builder.Services.AddScoped<CookieAuthenticationEvents>();


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

            app.UseCookiePolicy();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
