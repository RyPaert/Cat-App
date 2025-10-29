using Catblog.Models.Accounts;
using Catblog.Models.Comments;
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
        [Required]
        public List<IFormFile>? Files { get; set; }
        [Required]
        public List<PostImage> Image { get; set; } = new List<PostImage>();
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }

        public int Like { get; set; }
        public virtual ICollection<Comment> UserComment { get; set; }
        public User User { get; set; }
    }
}