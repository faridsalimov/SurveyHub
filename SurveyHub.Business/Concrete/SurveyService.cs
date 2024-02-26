using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Concrete
{
    public class SurveyService : ISurveyService
    {
        private ISurveyDal _surveyDal;

        public SurveyService(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }

        public Task Add(Survey survey)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Survey>> GetAll()
        {
            return await _surveyDal.GetList();
        }

        public Task<Survey> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
