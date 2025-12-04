using System.Diagnostics;
using Catblog.Data;
using Catblog.Models;
using Catblog.Models.Post;
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
            var resultingInventory = _context.Posts
                .OrderByDescending(y => y.Like)
                .Select(x => new Post
                {
                    Id = x.Id,
                    Name = x.Name,
                    Title = x.Title,
                    Description = x.Description,
                    Gender = x.Gender,
                    Age = x.Age,
                    Species = x.Species,
                    Like = x.Like,
                    Image = (List<PostImage>)_context.FileToDatabase
                       .Where(t => t.PostId == x.Id)
                       .Select(z => new PostImage
                       {
                           PostId = z.ID,
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
