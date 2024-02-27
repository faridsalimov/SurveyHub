using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.DataAccess.EntityFramework;
using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Concrete
{
    public class ResponseService : IResponseService
    {
        private IResponseDal _responseDal;

        public ResponseService(IResponseDal responseDal)
        {
            _responseDal = responseDal;
        }
        public Task Add(Response response)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Response>> GetAll()
        {
            return await _responseDal.GetList();
        }

        public Task<Response> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Response response)
        {
            throw new NotImplementedException();
        }
    }
}
