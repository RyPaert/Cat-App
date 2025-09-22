using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Models.Cats
{
    public class Cat
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Species { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<CatImage> Image { get; set; } = new List<CatImage>();
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }

        public int Like { get; set; }

    }
}
