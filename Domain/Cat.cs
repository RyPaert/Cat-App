using Catblog.Models.Cats;
using System.ComponentModel.DataAnnotations;

namespace Catblog.Domain
{
    public class Cat
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Species { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }

        public decimal Rate { get; set; }
    }
}
