using Microsoft.AspNetCore.Mvc;
using Catblog.Data;
using Catblog.Dto;
using Catblog.ServiceInterFace;
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
        public IActionResult Create()
        {
            Create vm = new();
            return View("Create",vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create vm)
        {
            var dto = new KittyDto
            {
                AdminCatName = vm.AdminCatName,
                AdminCatTitle = vm.AdminCatTitle,
                AdminCatSpecies = vm.AdminCatSpecies,
                AdminCatAge = vm.AdminCatAge,
                AdminCatGender = vm.AdminCatGender,
                AdminCatDescription = vm.AdminCatDescription,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    AdminCatID = x.Id,

                }).ToArray()
            };
            var result = await _kittyServices.Create(dto);


                if (result == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index","Home", vm);
            
        }

    };
}

