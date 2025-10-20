using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Kittys
{
    public class KittyImageViewModel
    {
        [Key]
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? KittyID { get; set; }
    }
}

