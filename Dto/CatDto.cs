using Catblog.Models.Cats;
using System.ComponentModel.DataAnnotations;

namespace Catblog.Dto
{
    public class CatDto
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
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }

        public decimal Rate { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
