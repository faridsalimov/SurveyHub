using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Abstract
{
    public interface IResponseService
    {
        Task<List<Response>> GetAll();
        Task Add(Response response);
        Task Update(Response response);
        Task Delete(int id);
        Task<Response> GetById(int id);
    }
}
