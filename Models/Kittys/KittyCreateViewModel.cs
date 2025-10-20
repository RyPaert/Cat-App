using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Kittys
{
    public class KittyCreateViewModel
    {
        [Key]
        public Guid AdminCatId { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }

        public List<IFormFile>? Files { get; set; }
        public List<KittyImageViewModel> kittyImageViewModels { get; set; } = new List<KittyImageViewModel>();
    }
}
