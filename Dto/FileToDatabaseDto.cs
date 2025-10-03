using System.ComponentModel.DataAnnotations;

namespace Catblog.Dto
{
    public class FileToDatabaseDto
    {
        public Guid ID { get; set; }
        public Guid ImageID { get; set; }
        [Required]
        public string? ImageTitle { get; set; }
        [Required]
        public byte[]? ImageData { get; set; }
        public Guid? PostId { get; set; }
    }
}
