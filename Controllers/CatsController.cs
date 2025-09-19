using Catblog.Data;
using Catblog.Dto;
using Catblog.Models.Cats;
using Catblog.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers
{
    public class CatsController : Controller
    {
        private readonly CatblogDb _context;
        private readonly ICatServices _catServices;
        private readonly IFileServices _fileServices;
        public CatsController(CatblogDb context, ICatServices catServices, IFileServices fileServices) 
        { 
            _context = context;
            _fileServices = fileServices;
            _catServices = catServices;
        }
        public IActionResult Index()
        {
            return View("AddNewPost");
        }
        [HttpGet]
        public IActionResult AddNewPost() 
        {
            Cat model = new();
            return View("AddNewPost", model);
        }
        [HttpPost, ActionName("AddNewPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewPost(Cat model)
        {
            var dto = new CatDto()
            {
                Name = model.Name,
                Age = model.Age,
                Title = model.Title,
                Description = model.Description,
                Species = model.Species,
                Gender = model.Gender,
                Files = model.Files,
                Image = model.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CatId = x.CatId,
                }).ToArray()
            };
            var result = await _catServices.AddNewPost(dto);

            if (result == null)
            {
                return RedirectToAction("Index" , "Home");
            }

            return RedirectToAction("Index", "Home", model);
        }
    }
}
