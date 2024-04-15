using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArtUnivercity.Application.Contract.Student;
using ArtUnivercity.Domain.StudentDomain;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;

namespace ArtUniversity.Infrastucture.EfCore.Repositories
{
    public class StudentRepository : RepositoryBase<long, Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public EditStudent GetDetails(long id)
        {
            EditStudent? query =_dbContext.Students.Select(x => new EditStudent()
            {
                Id=x.Id,
                Name = x.Name.Trim(),
                Family = x.Family.Trim(),
                FatherName=x.FatherName.Trim(),
                PersenalyCode=x.PersenalyCode.Trim(),
                NationalCode=x.NationalCode.Trim(),
                MobileNumber=x.MobileNumber.Trim(),
                Address=x.Address.Trim(),
                Description = x.Description.Trim(),
                MetaDescription = x.MetaDescription.Trim(),
                KeyWord = x.KeyWord.Trim(),
                Picture = x.Picture.Trim(),
                PictureAlt = x.PictureAlt.Trim(),
                PictureTitle = x.PictureTitle.Trim(),
                Slug = x.Slug.Trim()
            }).FirstOrDefault(x => x.Id == id);

            if (query == null)
            {
                return null;
            }

            return query;
        }

        public List<StudentViewModel> GetStudents()
        {
            var items = _dbContext.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name.Trim()+" "+x.Family.Trim(),
                PersenalyCode = x.PersenalyCode.Trim(),
                NationalCode = x.NationalCode.Trim(),
                MobileNumber = x.MobileNumber.Trim(),
                Description = x.Description.Trim(),
                Address = x.Address.Trim(),
                FatherName = x.FatherName.Trim(),
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture.Trim(),
                IsStated=x.IsDeleted
            });



            return items.ToList();
        }

        public List<StudentViewModel> Search(StudentSearchModel searchModel)
        {
            var query = _dbContext.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name.Trim()+" "+x.Family,
                FatherName = x.FatherName.Trim(),
                PersenalyCode = x.PersenalyCode.Trim(),
                NationalCode = x.NationalCode.Trim(),
                MobileNumber = x.MobileNumber.Trim(),
                Address = x.Address.Trim(),
                Description = x.Description.Trim(),
                CreationDate = x.CreationDate.ToFarsi(),
                Picture=x.Picture,
                IsStated=x.IsDeleted
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query=query.Where(x=>x.Name.Contains(searchModel.Name.Trim())); 
            }

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
