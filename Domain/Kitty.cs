using Catblog.Models;

namespace Catblog.Domain
{
    public class Kitty
    {
        public Guid ID { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        public AdminCat adminCat { get; set; }
    }
}
