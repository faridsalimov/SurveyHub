using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Dtos;

namespace SurveyHub.WebUI.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        private UserManager<CustomIdentityUser> _userManager;

        public UserInfoViewComponent(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var userInfoDto = new UserInfoDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
            };

            return View(userInfoDto);
        }
    }
}
