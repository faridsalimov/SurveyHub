using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Dtos;

namespace SurveyHub.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private CustomIdentityDbContext _customIdentityDbContext;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, CustomIdentityDbContext customIdentityDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _customIdentityDbContext = customIdentityDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CustomIdentityUserLoginDto customIdentityUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var signIn = await _signInManager.PasswordSignInAsync(customIdentityUserLoginDto.Username, customIdentityUserLoginDto.Password, customIdentityUserLoginDto.RememberMe, false);
                if (signIn.Succeeded)
                {
                    var customIdentityUser = _customIdentityDbContext.Users.SingleOrDefault(i => i.UserName == customIdentityUserLoginDto.Username);
                    if (customIdentityUser != null)
                    {
                        _customIdentityDbContext.Update(customIdentityUser);
                        await _customIdentityDbContext.SaveChangesAsync();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(customIdentityUserLoginDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CustomIdentityUserRegisterDto customIdentityUserRegisterDto)
        {
            if (ModelState.IsValid && customIdentityUserRegisterDto.IsAcceptTermsAndPrivacy)
            {
                CustomIdentityUser customIdentityUser = new CustomIdentityUser()
                {
                    Name = customIdentityUserRegisterDto.Name,
                    Surname = customIdentityUserRegisterDto.Surname,
                    UserName = customIdentityUserRegisterDto.Username,
                    Email = customIdentityUserRegisterDto.Email
                };

                var result = await _userManager.CreateAsync(customIdentityUser, customIdentityUserRegisterDto.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("User"))
                    {
                        var customIdentityRole = new CustomIdentityRole
                        {
                            Name = "User",
                        };

                        var result2 = await _roleManager.CreateAsync(customIdentityRole);
                        if (!result2.Succeeded)
                        {
                            ModelState.AddModelError("", "Error");
                            return View(customIdentityUserRegisterDto);
                        }
                    }

                    await _userManager.AddToRoleAsync(customIdentityUser, "User");
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(customIdentityUserRegisterDto);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _customIdentityDbContext.Update(user);
            await _customIdentityDbContext.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
