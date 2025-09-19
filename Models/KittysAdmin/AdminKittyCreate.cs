namespace Catblog.Models.KittysAdmin
{
    public class AdminKittyCreate
    {
        public int AdminCatId {  get; set; }
        public string AdminCatName { get; set; }
        public string AdminCatSpecies { get; set; }
        public int AdminCatAge { get; set; }
        public string AdminCatGender { get; set; }
        public string AdminCatDescription { get; set; }
        public int AdminCatRate { get; set; }
        public AdminKittyCreate adminKittyCreate { get; set; }
    }
}
