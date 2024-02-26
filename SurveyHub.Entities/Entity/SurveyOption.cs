using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Entities.Entity
{
    public class SurveyOption
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string? Text { get; set; }
    }
}
