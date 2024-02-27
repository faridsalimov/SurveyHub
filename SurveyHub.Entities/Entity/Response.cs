using SurveyHub.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Entities.Entity
{
    public class Response : IEntity
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int OptionId { get; set; }
        public virtual CustomIdentityUser? User { get; set; }
    }
}
