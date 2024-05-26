using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.GroupStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation
{
    public interface IFieldOfStudyAndOrientationApplication
    {
        OperationResult Create(CreateFieldOfStudyAndOrientation command);
        OperationResult Update(EditFieldOfStudyAndOrientation command);
        EditFieldOfStudyAndOrientation GetCourse(long id);
        List<FieldOfStudyAndOrientationViewModel> GetAll();
        List<FieldOfStudyAndOrientationViewModel> Search(FieldOfStudyAndOrientationSearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
