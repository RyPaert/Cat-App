using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Accounts
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmed { get; set; }
        public bool isAdmin { get; set; } = false;
    }
}