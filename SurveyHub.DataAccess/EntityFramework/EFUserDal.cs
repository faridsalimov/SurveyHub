using SurveyHub.Core.DataAccess.EntityFramework;
using SurveyHub.DataAccess.Abstract;
using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.DataAccess.EntityFramework
{
    public class EFUserDal : EFEntityFrameworkRepositoryBase<CustomIdentityUser, CustomIdentityDbContext>, IUserDal
    {
    }
}
