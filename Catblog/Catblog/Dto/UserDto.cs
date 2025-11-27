using System.ComponentModel.DataAnnotations;

namespace Catblog.Dto
{
	public class UserDto
	{
		public Guid Id { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string PasswordConfirmed { get; set; }
	}
}
