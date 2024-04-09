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
                Name = x.Name + " " + x.Family,
                PersenalyCode = x.PersenalyCode,
                NationalCode = x.NationalCode,
                MobileNumber = x.MobileNumber,
                Description = x.Description,
                Address = x.Address,
                FatherName = x.FatherName,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,

            });



            return items.ToList();
        }

        public List<StudentViewModel> Search(StudentSearchModel search)
        {
            var query = _dbContext.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name.Trim() + " " + x.Family.Trim(),
                FatherName = x.FatherName.Trim(),
                PersenalyCode = x.PersenalyCode.Trim(),
                NationalCode = x.NationalCode.Trim(),
                MobileNumber = x.MobileNumber.Trim(),
                Address = x.Address.Trim(),
                Description = x.Description.Trim(),
                CreationDate = x.CreationDate.ToString()
            });

            if (string.IsNullOrEmpty(search.Name))
            {
                query=query.Where(x=>x.Name.Contains(search.Name)); 
            }

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
