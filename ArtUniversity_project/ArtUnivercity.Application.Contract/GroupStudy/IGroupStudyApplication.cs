using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.GroupStudy
{
    public interface IGroupStudyApplication
    {
        OperationResult Create(CreateGroupStudy command);
        OperationResult Update(EditGroupStudy command);
        EditGroupStudy GetGroupStudy(long id);
        List<GroupStudyViewModel> GetAll();
        List<GroupStudyViewModel> Search(GroupStudySearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
