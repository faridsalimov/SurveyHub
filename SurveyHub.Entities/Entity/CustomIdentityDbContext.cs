using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Entities.Entity
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Response> Responses { get; set; }

        public CustomIdentityDbContext() { }
    }
}
