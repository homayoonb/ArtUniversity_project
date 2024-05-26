using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Course
{
    public interface ICourseApplication
    {
        OperationResult Create(CreateCourse command);
        OperationResult Update(EditCourse command);
        EditCourse GetCourse(long id);
        List<CourseViewModel> GetAll();
        List<CourseViewModel> Search(CourseSearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
