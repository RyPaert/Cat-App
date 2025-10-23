using Catblog.Data;
using Catblog.Dto;
using Catblog.Models.Post;
using Catblog.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Controllers
{
    public class PostController : Controller
    {
        private readonly CatblogDb _context;
        private readonly IPostServices _postServices;
        private readonly IFileServices _fileServices;

        public PostController(CatblogDb context, IPostServices postServices, IFileServices fileServices)
        {
            _context = context;
            _postServices = postServices;
            _fileServices = fileServices;
        }

        [HttpGet]
        public IActionResult AddNewPost()
        {
            Post model = new();
            return View("AddNewPost", model);
        }
        [HttpPost, ActionName("AddNewPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewPost(Post model)
        {
            if (model.Files == null || !model.Files.Any())
            {
                ViewBag.ErrorMessage = "Palun lisa pilt!";
                return View(model);
            }
            var dto = new PostDto()
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
                    PostId = x.PostId,
                }).ToArray()
            };
            var result = await _postServices.AddNewPost(dto);

            if (result == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home", model);
        }
        [HttpGet]
        public async Task<IActionResult> PostDetails(Guid id, bool like)
        {
            var post = await _postServices.PostDetailsAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(t => t.PostId == id)
                .Select(y => new PostImage
                {
                    PostId = y.ID,
                    ImageId = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new Post();
            vm.Id = post.Id;
            vm.Name = post.Name;
            vm.Age = post.Age;
            vm.Description = post.Description;
            vm.Like = post.Like;
            vm.Gender = post.Gender;
            vm.Species = post.Species;
            vm.Title = post.Title;
            vm.Like = post.Like;
            vm.Image.AddRange(images);

            return View(vm);
        }
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            if (id == Guid.Empty) { return BadRequest("Invalid ID"); }
            var filmToDelete = await _postServices.Delete(id);

            if (filmToDelete == null) { return RedirectToAction("Index", "Home"); }

            return RedirectToAction("Index", "Home");
        }
    }
}
