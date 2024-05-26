using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Application.Contract.GroupStudy;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Application.Contract.Student;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUnivercity.Domain.GroupStudyDomain;
using ArtUnivercity.Domain.ProfessorDomain;
using ArtUnivercity.Domain.StudentDomain;
using ArtUniversity.Application.Course;
using ArtUniversity.Application.Department;
using ArtUniversity.Application.FieldOfStudyAndOrientation;
using ArtUniversity.Application.GroupStudy;
using ArtUniversity.Application.Professor;
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
            services.AddTransient<IProfessorApplication, ProfessorApplication>();
            services.AddTransient<ICourseApplication, CourseApplication>();
            services.AddTransient<IGroupStudyApplication, GroupStudyApplication>();
            services.AddTransient<IFieldOfStudyAndOrientationApplication, FieldOfStudyAndOrientationApplication>();
            services.AddTransient<IDepartmentApplication, DepartmentApplication>();
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
