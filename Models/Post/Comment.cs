using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Post
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid? PostId { get; set; }
    }
}
