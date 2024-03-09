using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;

namespace SurveyHub.Business.Concrete
{
    public class SurveyService : ISurveyService
    {
        private ISurveyDal _surveyDal;

        public SurveyService(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }

        public async Task Add(Survey survey)
        {
            await _surveyDal.Add(survey);
        }

        public async Task Delete(int id)
        {
            var item = await _surveyDal.Get(s => s.Id == id);
            await _surveyDal.Delete(item);
        }

        public async Task<List<Survey>> GetAll()
        {
            return await _surveyDal.GetList();
        }

        public async Task<Survey> GetById(int id)
        {
            return await _surveyDal.Get(s => s.Id == id);
        }

        public async Task Update(Survey survey)
        {
            await _surveyDal.Update(survey);
        }
    }
}
