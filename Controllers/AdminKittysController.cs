using Microsoft.AspNetCore.Mvc;
using Catblog.Data;
using Catblog.Dto;
using Catblog.ServiceInterFace;
using Catblog.Domain;
using Microsoft.EntityFrameworkCore;
using Catblog.Models.AdminKittys;



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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _catContext.Kitties.ToListAsync();
            return View(result);                      
        }

        [HttpGet]
        public IActionResult Create()
        {
            Kitty vm = new();
            return View("Create",vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KittyDto vm, Photo photo)
        {
            var dto = new KittyDto
            {
                AdminCatName = vm.AdminCatName,
                AdminCatSpecies = vm.AdminCatSpecies,
                AdminCatAge = vm.AdminCatAge,
                AdminCatGender = vm.AdminCatGender,
                AdminCatDescription = vm.AdminCatDescription,
                AdminCatRate = vm.AdminCatRate,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                   ImageTitle = x.ImageTitle,
                    AdminCatID = x.AdminCatID,

                }).ToArray()
            };
            var result = await _kittyServices.Create(dto);


                if (result == null)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", vm);
           
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delete = await _catContext.Kitties
        .FirstOrDefaultAsync(x => x.Id == id);

            if (delete == null)
            {
                return NotFound();
            }
            var vm = new Kitty
            {
                Id = delete.Id,
                AdminCatName = delete.AdminCatName,
                AdminCatSpecies = delete.AdminCatSpecies,
                AdminCatAge = delete.AdminCatAge,
                AdminCatGender = delete.AdminCatGender,
                AdminCatDescription = delete.AdminCatDescription,
                AdminCatRate = delete.AdminCatRate
            };
            return View(vm);
        }
    };
}

