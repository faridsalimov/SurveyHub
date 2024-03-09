using SurveyHub.Entities.Entity;

namespace SurveyHub.WebUI.Dtos
{
    public class ProfileDto
    {
        public CustomIdentityUser? User { get; set; }
        public IFormFile? File { get; set; }
        public string? ImageUrl { get; set; }
        public int SurveysCount { get; set; }
        public int VotesCount { get; set; }
        public bool IsSelf { get; set; } = false;
    }
}
