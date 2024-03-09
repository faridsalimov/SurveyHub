using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;

namespace SurveyHub.Business.Concrete
{
    public class OptionService : IOptionService
    {
        private IOptionDal _optionDal;

        public OptionService(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }

        public async Task Add(Option option)
        {
            await _optionDal.Add(option);
        }

        public async Task Delete(int id)
        {
            var item = await _optionDal.Get(o => o.Id == id);
            await _optionDal.Delete(item);
        }

        public async Task<List<Option>> GetAll()
        {
            return await _optionDal.GetList();
        }

        public async Task<Option> GetById(int id)
        {
            return await _optionDal.Get(o => o.Id == id);
        }

        public async Task Update(Option option)
        {
            await _optionDal.Update(option);
        }
    }
}
