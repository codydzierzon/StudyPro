using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyPro.Models.Authentication;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Authentication;
using StudyPro.Models.Interfaces.Data;

namespace StudyPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthService _authService;
        private readonly IUserService _userService;

        public AccountController(IUserAuthService authService, IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public async Task<IActionResult> Login(string? returnUrl, Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            User? user = _userService.ValidateUser(login);

            if (user == null)
            {
                ModelState.AddModelError("Login.UserName", "The UserName or Password is incorrect.");
                return View(login);
            }

            await _authService.SignIn(user);

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOut();

            return Redirect("/Account/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Registration());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {

            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            var user = _userService.Register(registration);

            if (user == null)
            {
                return View(registration);
            }

            return Redirect("/Account/Login");
        }
    }
}
