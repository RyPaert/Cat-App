

using Catblog.Models.AdminKittys;

namespace Catblog.Dto
{
    public class KittyDto
    {
        public Guid Id { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        //public KittyCreateViewModel createViewModel { get; set; }
        public Photo photo { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image {  get; set; } = new List<FileToDatabaseDto>();

        


    }
    

}
