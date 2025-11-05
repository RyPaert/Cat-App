using System.Security.Claims;
using System.Threading.Tasks;
using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers.Accounts
{
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    PasswordConfirmed = model.ConfirmPassword
                    
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = await _userManager.FindByNameAsync(userModel.UserName);
            if (user != null &&
                await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));


                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = userModel.RememberMe,
                    ExpiresUtc = userModel.RememberMe ? DateTime.UtcNow.AddMinutes(10) : (DateTime?)null

                };
				Console.WriteLine($"TEST LINE:\nREMEMBER ME IS {userModel.RememberMe}\nCURRENT TIME IS {DateTime.UtcNow}\n YOUR COOKIE WILL EXPIRE AT {authProperties.ExpiresUtc}");

				await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
	            new ClaimsPrincipal(identity), authProperties);

				return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
    }
}
