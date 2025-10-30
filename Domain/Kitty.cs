

using System.ComponentModel.DataAnnotations;
using Catblog.Dto;

namespace Catblog.Domain
{
    public class Kitty
    {
        [Key]
        public Guid Id { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        //public KittyCreateViewModel kittyCreateViewModel { get; set; }

        public List<byte[]> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        
    }
}
