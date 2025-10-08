using System.ComponentModel.DataAnnotations;

namespace Catblog.Domain
{
    public class FileToDatabase
    {
        public Guid ID { get; set; }
        [Required]
        public string? ImageTitle { get; set; }
        [Required]
        public byte[]? ImageData { get; set; }
        public Guid? PostId { get; set; }
    }
}
