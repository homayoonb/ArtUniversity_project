using _0_Framework.Domain;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Application.Contract.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.ProfessorDomain
{
    public interface IProfessorRepository : IRepository<long, Professor>
    {
        EditProfessor GetDetails(long id);
        List<ProfessorViewModel> GetProfessors();
        List<ProfessorViewModel> Search(ProfessorSearchModel searchModel);
    }
}
