using Catblog.Data;
using Catblog.Models.Cats;
using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers
{
    public class CatsController : Controller
    {
        private readonly CatblogDb _context;
        public CatsController(CatblogDb context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View("AddNewPost");
        }
        public IActionResult AddNewPost(Cat cat) 
        { 
            _context.Cats.AddAsync(cat);
            _context.SaveChangesAsync();  
            var allCats = _context.Cats.ToList();
            return RedirectToAction("Index", "Home", allCats);
        }
    }
}
