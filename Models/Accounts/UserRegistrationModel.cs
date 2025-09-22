using System.ComponentModel.DataAnnotations;

namespace Catblog.Models.Accounts
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Username is required!")]
		public string UserName { get; set; }

        [Required(ErrorMessage = "a Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "an Email is required!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "the Passwords do not match!")]
        [Required(ErrorMessage = "Password confirmation is required!")]
        public string ConfirmPassword { get; set; }

    }
}
