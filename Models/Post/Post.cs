using Catblog.Models.Post;
using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Post
{
    public class Post
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
        public List<IFormFile>? Files { get; set; }
        public List<PostImage> Image { get; set; } = new List<PostImage>();
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }

        public int Like { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
