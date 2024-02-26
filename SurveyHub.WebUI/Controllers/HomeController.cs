using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyHub.Business.Abstract;
using SurveyHub.Entities.Entity;
using SurveyHub.WebUI.Models;
using System.Diagnostics;

namespace SurveyHub.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private readonly IUserService _userService;
        private IWebHostEnvironment _webHost;
        private CustomIdentityDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<CustomIdentityUser> userManager, IUserService userService, IWebHostEnvironment webHost, CustomIdentityDbContext dbContext, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _userService = userService;
            _webHost = webHost;
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> GetAllSurveys()
        {
            var data = await _dbContext.Surveys.ToListAsync();

            var userIds = data.Select(survey => survey.Creator.Id).ToList();

            var users = await _dbContext.Users
                .Where(user => userIds.Contains(user.Id))
                .ToListAsync();

            var userDictionary = users.ToDictionary(user => user.Id);

            foreach (var survey in data)
            {
                if (userDictionary.TryGetValue(survey.Creator.Id, out var user))
                {
                    survey.Creator = user;
                }

                string publishTimeString = survey.PublishTime.ToString();
                DateTime surveyDateTime = DateTime.Parse(publishTimeString);
                string formattedDateTime = surveyDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                formattedDateTime = formattedDateTime.Replace("T", " ");
                survey.PublishTime = surveyDateTime;
            }

            return Ok(data);
        }

    }
}
