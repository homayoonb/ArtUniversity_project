using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.CourseDomain
{
    public interface ICourseRepository : IRepository<long,Course>
    {
    }
}
