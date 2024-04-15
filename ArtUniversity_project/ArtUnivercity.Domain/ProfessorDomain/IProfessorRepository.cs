using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.ProfessorDomain
{
    public interface IProfessorRepository : IRepository<long, Professor>
    {
    }
}
