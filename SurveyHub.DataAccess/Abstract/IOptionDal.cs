using SurveyHub.Core.DataAccess;
using SurveyHub.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyHub.DataAccess.Abstract
{
    public interface IOptionDal : IEntityRepository<Option>
    {
    }
}
