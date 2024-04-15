using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Student
{
    public interface IStudentApplication
    {
        OperationResult Create(CreateStudent command);
        OperationResult Update(EditStudent command);
        EditStudent GetStudents(long id);
        List<StudentViewModel> GetAll();
        List<StudentViewModel> Search(StudentSearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
