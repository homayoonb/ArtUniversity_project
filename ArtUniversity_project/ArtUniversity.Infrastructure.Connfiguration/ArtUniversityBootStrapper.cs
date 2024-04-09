using ArtUnivercity.Application.Contract.Student;
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
            services.AddTransient<IStudentApplication, StudentApplication>();
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
