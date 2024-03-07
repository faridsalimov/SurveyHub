using System.ComponentModel.DataAnnotations;

namespace SurveyHub.WebUI.Dtos
{
    public class AddSurveyDto
    {
        [Required]
        public string? Content { get; set; }
        [Required]
        public string[]? Options { get; set; }
    }
}
