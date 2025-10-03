using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Accounts
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "an Email is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "a Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name  = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
