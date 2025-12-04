using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
