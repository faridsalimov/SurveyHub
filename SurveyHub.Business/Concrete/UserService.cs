using SurveyHub.Business.Abstract;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;

namespace SurveyHub.Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task Add(CustomIdentityUser user)
        {
            await _userDal.Add(user);
        }

        public async Task Delete(string id)
        {
            var item = await _userDal.Get(u => u.Id == id);
            await _userDal.Delete(item);
        }

        public async Task<List<CustomIdentityUser>> GetAll()
        {
            return await _userDal.GetList();
        }

        public async Task<CustomIdentityUser> GetById(string id)
        {
            return await _userDal.Get(s => s.Id == id);
        }

        public async Task Update(CustomIdentityUser user)
        {
            await _userDal.Update(user);
        }
    }
}
