using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyHub.Entities.Entity;
using System.ComponentModel.DataAnnotations;

namespace SurveyHub.WebUI.Dtos
{
    public class AddSurveyDto
    {
        [Required]
        public string? Content { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string[]? Options { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public AddSurveyDto()
        {
            Categories = Enum.GetValues(typeof(Category))
                             .Cast<Category>()
                             .Select(category => new SelectListItem
                             {
                                 Value = ((int)category).ToString(),
                                 Text = category.ToString()
                             })
                             .ToList();
        }
    }
}
