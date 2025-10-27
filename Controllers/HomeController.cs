using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Catblog.Data;
using Catblog.Domain;
using Catblog.Models;
using Catblog.Models.AdminKittys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdminCatContext _catContext;

        public HomeController(ILogger<HomeController> logger, AdminCatContext adminCatContext)
        {
            _logger = logger;
            _catContext = adminCatContext;
        }
        public IActionResult Index()
        {
            var resultingInventory = _catContext.Kitties
                .Select(x => new Kitty
                {
                    Id = x.Id,
                    AdminCatTitle = x.AdminCatTitle,
                    AdminCatDescription = x.AdminCatDescription,
                    AdminCatName = x.AdminCatName,
                    AdminCatAge = x.AdminCatAge,
                    AdminCatGender = x.AdminCatGender,
                    AdminCatSpecies = x.AdminCatSpecies,
                    Image = (List<Photo>)_catContext.FileToDatabase
                       .Where(t => t.Id == x.Id)
                       .Select(z => new Photo
                       {
                           ImageID = z.Id,
                           KittyID = z.Id,
                           ImageData = z.ImageData,
                           ImageTitle = z.ImageTitle,
                           Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(z.ImageData))
                       })
                });
            return View(resultingInventory);

        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
