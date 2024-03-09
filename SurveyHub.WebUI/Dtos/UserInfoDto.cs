using SurveyHub.Entities.Entity;

namespace SurveyHub.WebUI.Dtos
{
    public class UserInfoDto
    {
        public CustomIdentityUser? User { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
