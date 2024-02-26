using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Abstract
{
    public interface ISurveyService
    {
        Task<List<Survey>> GetAll();
        Task Add(Survey survey);
        Task Update(Survey survey);
        Task Delete(int id);
        Task<Survey> GetById(int id);
    }
}
