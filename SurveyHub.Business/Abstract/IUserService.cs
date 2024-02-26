using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.Business.Abstract
{
    public interface IUserService
    {
        Task<List<CustomIdentityUser>> GetAll();
        Task Add(CustomIdentityUser user);
        Task Update(CustomIdentityUser user);
        Task Delete(int id);
        Task<CustomIdentityUser> GetById(int id);
    }
}
