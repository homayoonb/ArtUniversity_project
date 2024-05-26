using _0_Framework.Domain;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.DepartmentDomain
{
    public interface IDepartmentRepository : IRepository<long,Department>
    {
        EditDepartment GetDetails(long id);
        List<DepartmentViewModel> GetDepartments();
        List<DepartmentViewModel> Search(DepartmentSearchModel searchModel);
    }
}
