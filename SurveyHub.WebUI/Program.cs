using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SurveyHub.Business.Abstract;
using SurveyHub.Business.Concrete;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.DataAccess.EntityFramework;
using SurveyHub.Entities.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ISurveyDal, EFSurveyDal>();
builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.Services.AddScoped<IOptionDal, EFOptionDal>();
builder.Services.AddScoped<IOptionService, OptionService>();

builder.Services.AddScoped<IResponseDal, EFResponseDal>();
builder.Services.AddScoped<IResponseService, ResponseService>();

var connection = builder.Configuration.GetConnectionString("LocalConnection");
builder.Services.AddDbContext<CustomIdentityDbContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();