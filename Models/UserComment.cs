using System.ComponentModel.DataAnnotations;

namespace Catblog.Models
{
    public class UserComment
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string? Description { get; set; }
        public Guid CatId { get; set; }
        //public int Like {  get; set; } vb teen
    }
}
