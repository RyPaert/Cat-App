using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Catblog.Controllers.Accounts
{
    public class AccountsController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistrationModel userModel)
        {
            return View();
        }
    }
}
