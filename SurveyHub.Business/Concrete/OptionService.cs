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
    public class OptionService : IOptionService
    {
        private IOptionDal _optionDal;

        public OptionService(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }

        public Task Add(Option option)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Option>> GetAll()
        {
            return await _optionDal.GetList();
        }

        public Task<Option> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Option option)
        {
            throw new NotImplementedException();
        }
    }
}
