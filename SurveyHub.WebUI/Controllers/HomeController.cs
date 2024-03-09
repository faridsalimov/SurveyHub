using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SurveyHub.Business.Abstract;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Dtos;
using SurveyHub.WebUI.Models;
using System.Diagnostics;

namespace SurveyHub.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private readonly IUserService _userService;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private IWebHostEnvironment _webHost;
        private CustomIdentityDbContext _dbContext;
        private ISurveyService _surveyService;

        public HomeController(UserManager<CustomIdentityUser> userManager, IUserService userService, RoleManager<CustomIdentityRole> roleManager, IWebHostEnvironment webHost, CustomIdentityDbContext dbContext, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
            _webHost = webHost;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSurvey()
        {
            var addSurveyDto = new AddSurveyDto();
            return View(addSurveyDto);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var surveys = await _dbContext.Surveys.ToListAsync();
            var options = await _dbContext.Options.ToListAsync();
            var responses = await _dbContext.Responses.ToListAsync();
            var userResponses = await _dbContext.Responses.Where(r => r.UserId == user.Id).ToListAsync();

            var userIds = surveys.Select(survey => survey.CreatorId).ToList();
            var users = await _dbContext.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
            var userDictionary = users.ToDictionary(u => u.Id);

            surveys = surveys.OrderByDescending(survey => survey.PublishTime).ToList();

            foreach (var survey in surveys)
            {
                if (userDictionary.TryGetValue(survey.CreatorId, out var surveyCreator))
                {
                    survey.Creator = surveyCreator;
                }

                string category = ((Category)survey.CategoryId).ToString();
                survey.Category = category;

                string publishTimeString = survey.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime surveyDateTime = DateTime.Parse(publishTimeString);
                survey.PublishTime = surveyDateTime;
            }

            var data = new { Surveys = surveys, Options = options, Responses = responses, UserResponses = userResponses };

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveResponse(int surveyId, int optionId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var survey = await _dbContext.Surveys.FirstOrDefaultAsync(s => s.Id == surveyId);
            var option = await _dbContext.Options.FirstOrDefaultAsync(o => o.Id == optionId);

            var existingResponse = await _dbContext.Responses.FirstOrDefaultAsync(r => r.SurveyId == surveyId && r.UserId == user.Id);
            if (existingResponse != null)
            {
                existingResponse.OptionId = optionId;
            }

            else
            {
                var response = new Response
                {
                    SurveyId = surveyId,
                    OptionId = optionId,
                    User = user,
                    UserId = user.Id
                };

                _dbContext.Responses.Add(response);
            }

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSurvey(AddSurveyDto addSurveyDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                var survey = new Survey
                {
                    Content = addSurveyDto.Content,
                    CategoryId = addSurveyDto.CategoryId,
                    PublishTime = DateTime.Now,
                    Creator = user,
                    CreatorId = user.Id
                };

                _dbContext.Surveys.Add(survey);
                await _dbContext.SaveChangesAsync();

                foreach (var optionText in addSurveyDto.Options)
                {
                    var option = new Option
                    {
                        SurveyId = survey.Id,
                        Text = optionText
                    };

                    _dbContext.Options.Add(option);
                }

                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(addSurveyDto);
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
