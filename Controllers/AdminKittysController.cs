using Microsoft.AspNetCore.Mvc;
using Catblog.Models;
using Catblog.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catblog.Dto;
using Catblog.Domain;
using Microsoft.AspNetCore.Components.Web;
using Catblog.ServiceInterFace;


namespace Catblog.Controllers
{
    public class AdminKittysController : Controller
    {
        private readonly AdminCatContext _catContext;
        private readonly IKittysServices _kittyServices;
        private readonly IFileServices _fileServices;

        public AdminKittysController(AdminCatContext catContext, IKittysServices kittyServices, IFileServices fileServices)
        {
            _catContext = catContext;
            _kittyServices = kittyServices;
            _fileServices = fileServices;
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
            var dto = new KittyDto
            {
                AdminCatName = vm.AdminCatName,
                AdminCatSpecies = vm.AdminCatSpecies,
                AdminCatAge = vm.AdminCatAge,
                AdminCatGender = vm.AdminCatGender,
                AdminCatDescription = vm.AdminCatDescription,
                Files = vm.Files,
                Image = vm.PhotoImages.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    AdminCatID = x.KittyID,

                }).ToArray()
            };
            var result = await _kittyServices.Create(dto);


                if (result == null)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", vm);
            
        }

    };
}

