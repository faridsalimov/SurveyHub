using System.ComponentModel.DataAnnotations;

namespace SurveyHub.WebUI.Dtos
{
    public class CustomIdentityUserLoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
