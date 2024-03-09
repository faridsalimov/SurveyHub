using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyHub.Entities.Entity;
using System.Data;

namespace SurveyHub.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private CustomIdentityDbContext _dbContext;

        public AdminController(UserManager<CustomIdentityUser> userManager, CustomIdentityDbContext dbContext, RoleManager<CustomIdentityRole> roleManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeleteSurvey(int surveyId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var survey = await _dbContext.Surveys.FirstOrDefaultAsync(s => s.Id == surveyId);

                if (survey == null)
                {
                    return NotFound();
                }

                var options = await _dbContext.Options.Where(o => o.SurveyId == surveyId).ToListAsync();
                var responses = await _dbContext.Responses.Where(r => r.SurveyId == surveyId).ToListAsync();

                _dbContext.Options.RemoveRange(options);
                _dbContext.Responses.RemoveRange(responses);

                _dbContext.Surveys.Remove(survey);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }

            return View();
        }
    }
}
