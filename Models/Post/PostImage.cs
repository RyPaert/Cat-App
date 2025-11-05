using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Post
{
    public class PostImage
    {
        public Guid ImageId { get; set; }
        [Required]
        public string? ImageTitle { get; set; }
        [Required]
        public byte[]? ImageData { get; set; }
        [Required]
        public string? Image { get; set; }
        public Guid? PostId { get; set; }
    }
}
