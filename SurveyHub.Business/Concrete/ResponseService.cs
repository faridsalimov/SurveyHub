using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;

namespace SurveyHub.Business.Concrete
{
    public class ResponseService : IResponseService
    {
        private IResponseDal _responseDal;

        public ResponseService(IResponseDal responseDal)
        {
            _responseDal = responseDal;
        }

        public async Task Add(Response response)
        {
            await _responseDal.Add(response);
        }

        public async Task Delete(int id)
        {
            var item = await _responseDal.Get(r => r.Id == id);
            await _responseDal.Delete(item);
        }

        public async Task<List<Response>> GetAll()
        {
            return await _responseDal.GetList();
        }

        public async Task<Response> GetById(int id)
        {
            return await _responseDal.Get(r => r.Id == id);
        }

        public async Task Update(Response response)
        {
            await _responseDal.Update(response);
        }
    }
}
