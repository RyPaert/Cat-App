using Microsoft.AspNetCore.Mvc;
using Catblog.Models;
using Catblog.Data;


namespace Catblog.Controllers
{
    public class AdminKittysController : Controller
    {
        private readonly AdminCatContext _catContext;

        public AdminKittysController(AdminCatContext catContext)
        {
            _catContext = catContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminCatId, AdminCatName, AdminCatSpecies, AdminCatGender, AdminCatDescription")]AdminCat adminCat)
        {
            if(ModelState.IsValid)
            {
                _catContext.adminCats.Add(adminCat);
                await _catContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(adminCat);
        }

    }
}
