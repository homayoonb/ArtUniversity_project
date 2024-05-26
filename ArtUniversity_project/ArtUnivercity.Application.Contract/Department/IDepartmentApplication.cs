using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Department
{
    public interface IDepartmentApplication
    {
        OperationResult Create(CreateDepartment command);
        OperationResult Update(EditDepartment command);
        EditDepartment GetDepartment(long id);
        List<DepartmentViewModel> GetAll();
        List<DepartmentViewModel> Search(DepartmentSearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
