using System.ComponentModel.DataAnnotations.Schema;

namespace Catblog.Domain
{
    public class FileToDatabase
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public Guid? AdminCatID { get; set; }

        [ForeignKey(nameof(AdminCatID))]
        public Kitty Kitty { get; set; }
        public string? Image {  get; set; }
    }
}
