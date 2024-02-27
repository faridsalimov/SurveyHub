using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

        public HomeController(UserManager<CustomIdentityUser> userManager, IUserService userService, IWebHostEnvironment webHost, CustomIdentityDbContext dbContext, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _userService = userService;
            _webHost = webHost;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
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
            }

            return Ok(data);
        }

    }
}
