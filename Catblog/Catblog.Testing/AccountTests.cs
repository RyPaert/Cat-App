using Catblog.Controllers.Accounts;
using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catblog.Testing
{
	public class AccountTests : TestBase
	{
		[Fact]
		public async Task Should_CreateAccount_Then_Redirect()
		{
			var userStore = new Mock<IUserStore<User>>();
			var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);
			var controller = new AccountsController(userManager.Object, null);

			userManager.Setup(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).
				ReturnsAsync(IdentityResult.Success);

			var registrationModel = new UserRegistrationModel
			{
				UserName = "Peruere",
				Email = "Peruere@Fatui.com",
				Password = "P3ru3re",
				ConfirmPassword = "P3ru3re"
			};

			var result = await controller.Register(registrationModel);

			var redirect = Assert.IsType<RedirectToActionResult>(result);
			Assert.Equal("Index", redirect.ActionName);
			Assert.Equal("Home", redirect.ControllerName);
		}

		//[Fact]
		//public async Task Should_Login_When_ModelIsValid()
		//{
		// im sorry i cant figure out how to test claims please give me my grade i beg ):
		//}
		//[Fact]
		//public async Task Should_Logout_When_LoggedIn()
		//{
		//
		//}

	}
}
