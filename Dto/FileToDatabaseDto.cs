namespace Catblog.Dto
{
    public class FileToDatabaseDto
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? AdminCatID { get; set; }

        public string? Image { get; set; }
    }
}
