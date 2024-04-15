using ArtUnivercity.Application.Contract.Student;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUnivercity.Domain.GroupStudyDomain;
using ArtUnivercity.Domain.ProfessorDomain;
using ArtUnivercity.Domain.StudentDomain;
using ArtUniversity.Application.Student;
using ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext;
using ArtUniversity.Infrastucture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtUniversity.Connfiguration
{
    public class ArtUniversityBootStrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IGroupStudyRepository, GroupStudyRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<IFieldOfStudyAndOrientationRepository, FieldOfStudyAndOrientationRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IStudentApplication, StudentApplication>();
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
