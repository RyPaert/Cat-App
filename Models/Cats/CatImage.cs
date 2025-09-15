using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Cats
{
    public class CatImage
    {
        public Guid ImageId { get; set; }
        [Required]
        public string? ImageTitle { get; set; }
        [Required]
        public byte[]? ImageData { get; set; }
        [Required]
        public string? Image {  get; set; }
        [Required]
        public string? FileLoaction { get; set; }
        public Guid CatId { get; set; }
    }
}
