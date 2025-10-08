using System.ComponentModel.DataAnnotations;
using Catblog.Models.Accounts;

namespace Catblog.Dto
{
    public class PostDto
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
        public User? User { get; set; }
        public int Like { get; set; }
        [Required]
        public List<IFormFile>? Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}