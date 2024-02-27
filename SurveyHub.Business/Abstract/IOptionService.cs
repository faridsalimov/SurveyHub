using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Abstract
{
    public interface IOptionService
    {
        Task<List<Option>> GetAll();
        Task Add(Option option);
        Task Update(Option option);
        Task Delete(int id);
        Task<Option> GetById(int id);
    }
}
