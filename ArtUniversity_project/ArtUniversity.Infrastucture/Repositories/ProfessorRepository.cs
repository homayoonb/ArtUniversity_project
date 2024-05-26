using _0_Framework.Infrastructure;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Domain.ProfessorDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class ProfessorRepository : RepositoryBase<long, Professor>, IProfessorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProfessorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public EditProfessor GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorViewModel> GetProfessors()
        {
            throw new NotImplementedException();
        }

        public List<ProfessorViewModel> Search(ProfessorSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
