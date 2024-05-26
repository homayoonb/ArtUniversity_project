using _0_Framework.Domain;
using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain
{
    public interface IFieldOfStudyAndOrientationRepository : IRepository<long,FieldOfStudyAndOrientation>
    {
        EditFieldOfStudyAndOrientation GetDetails(long id);
        List<FieldOfStudyAndOrientationViewModel> GetFieldOfStudyAndOrientations();
        List<FieldOfStudyAndOrientationViewModel> Search(FieldOfStudyAndOrientationSearchModel searchModel);
    }
}
