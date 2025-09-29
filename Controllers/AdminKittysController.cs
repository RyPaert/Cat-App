using Microsoft.AspNetCore.Mvc;
using Catblog.Models;
using Catblog.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Catblog.Controllers
{
    public class AdminKittysController : Controller
    {
        private readonly AdminCatContext _catContext;

        public AdminKittysController(AdminCatContext catContext)
        {
            _catContext = catContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdminCat vm = new();
            return View("Create",vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCat vm)
        {
            var dto = new KittyadminDto
            {
                AdminCatName = vm.AdminCatName,
                AdminCatSpecies = vm.AdminCatSpecies,
                AdminCatAge = vm.AdminCatAge,
                AdminCatGender = vm.AdminCatGender,
                AdminCatDescription = vm.AdminCatDescription,
                //File = vm.File,
                //Image = vm.Image.Select(x => new FilesToDatabaseDto)
                //{

                //}
                //    var result = await _kittyServices.Create(dto);


                //if (result == null)
                //{
                //    return RedirectToAction("Index");
                //}
                //return RedirectToAction("Index", vm);
            };
        }

    };
}

