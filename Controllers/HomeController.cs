using System.Diagnostics;
using Catblog.Data;
using Catblog.Models;
using Catblog.Models.Cats;
using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CatblogDb _context;

        public HomeController(ILogger<HomeController> logger, CatblogDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var resultingInventory = _context.Cats
                .OrderByDescending(y => y.Like)
                .Select(x => new Cat
                {
                    Id = x.Id,
                    Name = x.Name,
                    Title = x.Title,
                    Description = x.Description,
                    Gender = x.Gender,
                    Age = x.Age,
                    Species = x.Species,
                    Like = x.Like,
                    Image = (List<CatImage>)_context.FileToDatabase
                       .Where(t => t.CatId == x.Id)
                       .Select(z => new CatImage
                       {
                           CatId = z.ID,
                           ImageId = z.ID,
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
