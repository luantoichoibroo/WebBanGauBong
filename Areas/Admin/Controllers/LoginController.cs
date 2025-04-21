using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBanGauBong.Areas.Admin.Data;
using WebBanGauBong.Areas.Admin.ViewModels;

namespace WebBanGauBong.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Thông tin đăng nhập không chính xác!");
            return View("Index");
        }

        private async Task<IdentityResult> CreateUserAsync(RegisterViewModel registerVM)
        {
            var user = CreateApplicationUser(registerVM);
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            return result;
        }

        private ApplicationUser CreateApplicationUser(RegisterViewModel registerVM)
        {
            return new ApplicationUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                Email = registerVM.Email,
            };
        }
    }
}
