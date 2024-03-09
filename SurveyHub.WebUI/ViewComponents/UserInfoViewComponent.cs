using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Dtos;

namespace SurveyHub.WebUI.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;

        public UserInfoViewComponent(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            if (user == null)
            {
                return View(new UserInfoDto());
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            var userInfoDto = new UserInfoDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
                IsAdmin = isAdmin
            };

            ViewBag.UserInfo = JsonConvert.SerializeObject(userInfoDto);

            return View(userInfoDto);
        }
    }
}
