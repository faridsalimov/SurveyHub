using SurveyHub.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Entities.Entity
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual CustomIdentityUser? Creator { get; set; }
        public string? CreatorId { get; set; }
    }
}
