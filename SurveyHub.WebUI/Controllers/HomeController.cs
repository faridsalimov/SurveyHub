﻿using Microsoft.AspNetCore.Authorization;
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
        private CustomIdentityDbContext _dbContext;

        public HomeController(UserManager<CustomIdentityUser> userManager, CustomIdentityDbContext dbContext)
        {
            _userManager = userManager;
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
    }
}
