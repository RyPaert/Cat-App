using Catblog.Data;
using Catblog.Dto;
using Catblog.Models.Cats;
using Catblog.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> PostDetails(Guid id)
        {
            var cat = await _catServices.PostDetailsAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(t => t.CatId == id)
                .Select(y => new CatImage
                {
                    CatId = y.ID,
                    ImageId = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new Cat();
            vm.Id = cat.Id;
            vm.Name = cat.Name;
            vm.Age = cat.Age;
            vm.Description = cat.Description;
            vm.Like = cat.Like;
            vm.Gender = cat.Gender;
            vm.Species = cat.Species;
            vm.Title = cat.Title;
            vm.Image.AddRange(images);

            return View(vm);
        }
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            if (id == Guid.Empty) { return BadRequest("Invalid ID"); }
            var filmToDelete = await _catServices.Delete(id);

            if (filmToDelete == null) { return RedirectToAction("Index", "Home"); }

            return RedirectToAction("Index", "Home");
        }
    }
}
