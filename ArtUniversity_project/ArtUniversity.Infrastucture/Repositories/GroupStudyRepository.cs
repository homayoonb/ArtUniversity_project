using _0_Framework.Infrastructure;
using ArtUnivercity.Application.Contract.GroupStudy;
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

        public EditGroupStudy GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<GroupStudyViewModel> GetGroupStudies()
        {
            throw new NotImplementedException();
        }

        public List<GroupStudyViewModel> Search(GroupStudySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
