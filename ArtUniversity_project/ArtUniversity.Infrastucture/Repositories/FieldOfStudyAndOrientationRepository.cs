using _0_Framework.Infrastructure;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class FieldOfStudyAndOrientationRepository : RepositoryBase<long, FieldOfStudyAndOrientation>, IFieldOfStudyAndOrientationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FieldOfStudyAndOrientationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
