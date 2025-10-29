using System.Diagnostics;
using Catblog.Data;
using Catblog.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
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
