using System.ComponentModel.DataAnnotations;

namespace SurveyHub.WebUI.Dtos
{
    public class CustomIdentityUserRegisterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool IsAcceptTermsAndPrivacy { get; set; }
    }
}
