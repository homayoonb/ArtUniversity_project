using _0_Framework.Infrastructure;
using ArtUnivercity.Domain.GroupStudyDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class GroupStudyRepository : RepositoryBase<long, GroupStudy>, IGroupStudyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public GroupStudyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
