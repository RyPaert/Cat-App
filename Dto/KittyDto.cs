using Catblog.Models;

namespace Catblog.Dto
{
    public class KittyDto
    {
        public int AdminCatId { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        public AdminCat adminCat { get; set; }

        public List<IFormFile> AdminCatFiles { get; set; }
        public IEnumerable<FileToDatabaseDto> Image {  get; set; } = new List<FileToDatabaseDto>();


    }
    

}
