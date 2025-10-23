using Microsoft.AspNetCore.Mvc;
using Catblog.Data;
using Catblog.Dto;
using Catblog.ServiceInterFace;
using Catblog.Models.Kittys;



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
            KittyCreateViewModel vm = new();
            return View("Create",vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KittyCreateViewModel vm)
        {
            var dto = new KittyDto
            {
                AdminCatName = vm.AdminCatName,
                AdminCatSpecies = vm.AdminCatSpecies,
                AdminCatAge = vm.AdminCatAge,
                AdminCatGender = vm.AdminCatGender,
                AdminCatDescription = vm.AdminCatDescription,
                Files = vm.Files,
                Image = vm.kittyImageViewModels.Select(x => new FileToDatabaseDto
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
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", vm);
            
        }

    };
}

