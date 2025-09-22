using Microsoft.AspNetCore.Mvc;
using Catblog.Models.KittysAdmin;


namespace Catblog.Controllers
{
    public class AdminKittysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AdminCatId, AdminCatName, AdminCatSpecies, AdminCatGender, AdminCatDescription")]AdminKittyCreate adminKittys)
        //{
            
        //}
    }
}
