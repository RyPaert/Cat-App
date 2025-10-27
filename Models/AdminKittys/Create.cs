using System.ComponentModel.DataAnnotations.Schema;
using Catblog.Dto;

namespace Catblog.Models.AdminKittys
{
    public class Create
    {
        public Guid Id { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        public string AdminCatTitle {  get; set; }

        [NotMapped]
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
