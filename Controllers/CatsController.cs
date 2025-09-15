using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewPost() { 
            return View();
        }
    }
}
