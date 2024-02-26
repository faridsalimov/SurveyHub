using Microsoft.AspNetCore.Identity;
using SurveyHub.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Entities.Entity
{
    public class CustomIdentityUser : IdentityUser, IEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
