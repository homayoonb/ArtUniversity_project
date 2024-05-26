using _0_Framework.Infrastructure;
using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class DepartmentRepository : RepositoryBase<long, Department>,IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DepartmentViewModel> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public EditDepartment GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentViewModel> Search(DepartmentSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
