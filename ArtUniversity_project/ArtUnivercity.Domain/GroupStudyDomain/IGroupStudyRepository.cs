using _0_Framework.Domain;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Application.Contract.GroupStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.GroupStudyDomain
{
    public interface IGroupStudyRepository : IRepository<long, GroupStudy>
    {
        EditGroupStudy GetDetails(long id);
        List<GroupStudyViewModel> GetGroupStudies();
        List<GroupStudyViewModel> Search(GroupStudySearchModel searchModel);
    }
}
