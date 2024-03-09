using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Dtos;
using SurveyHub.WebUI.Helpers;

namespace SurveyHub.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private CustomIdentityDbContext _dbContext;
        private IWebHostEnvironment _webHost;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, CustomIdentityDbContext dbContext, IWebHostEnvironment webHost)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _webHost = webHost;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
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
                    var customIdentityUser = _dbContext.Users.SingleOrDefault(i => i.UserName == customIdentityUserLoginDto.Username);
                    if (customIdentityUser != null)
                    {
                        _dbContext.Update(customIdentityUser);
                        await _dbContext.SaveChangesAsync();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(customIdentityUserLoginDto);
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
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var localUser = await _userManager.GetUserAsync(HttpContext.User);
            if (localUser == null)
            {
                return NotFound();
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            var helper = new ImageHelper(_webHost);
            var userSurveysCount = await _dbContext.Surveys.Where(s => s.CreatorId == user.Id).CountAsync();
            var userVotesCount = await _dbContext.Responses.Where(r => r.UserId == user.Id).CountAsync();

            ProfileDto profileDto = new ProfileDto
            {
                User = user,
                SurveysCount = userSurveysCount,
                VotesCount = userVotesCount,
                IsSelf = (localUser == user)
            };

            if (profileDto.File != null)
            {
                profileDto.ImageUrl = await helper.SaveFile(profileDto.File);
                user.ImageUrl = profileDto.ImageUrl;
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
            }

            ViewBag.User = user;
            return View(profileDto);
        }
    }
}
