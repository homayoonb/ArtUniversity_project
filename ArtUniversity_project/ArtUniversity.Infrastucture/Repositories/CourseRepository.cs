using _0_Framework.Infrastructure;
using ArtUnivercity.Domain.CourseDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class CourseRepository : RepositoryBase<long, Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
