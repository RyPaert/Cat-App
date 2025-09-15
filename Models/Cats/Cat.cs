using System.ComponentModel.DataAnnotations;

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
        [Required]
        public List<CatImage> Image { get; set; } = new List<CatImage>();
        [Required]
        public string? Description { get; set; }

        public decimal Rate { get; set; }

    }
}
