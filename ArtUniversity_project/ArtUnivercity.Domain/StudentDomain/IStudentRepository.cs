using _0_Framework.Domain;
using ArtUnivercity.Application.Contract.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.StudentDomain
{
    public interface IStudentRepository : IRepository<long,Student>
    {
        EditStudent GetDetails(long id);
        List<StudentViewModel> GetStudents();
        List<StudentViewModel> Search(StudentSearchModel searchModel);
    }
}
