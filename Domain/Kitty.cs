using Catblog.Models.AdminKittys;

namespace Catblog.Domain
{
    public class Kitty
    {
        public Guid Id { get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        public string AdminCatTitle { get; set; }
        public Create create { get; set; }
        public List<Photo> Image { get; internal set; }
    }
}
