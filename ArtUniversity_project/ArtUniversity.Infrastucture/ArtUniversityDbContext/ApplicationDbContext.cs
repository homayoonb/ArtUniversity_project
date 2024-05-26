using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUnivercity.Domain.GroupStudyDomain;
using ArtUnivercity.Domain.ProfessorDomain;
using ArtUnivercity.Domain.StudentDomain;
using ArtUniversity.Infrastucture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<GroupStudy> GroupStudies => Set<GroupStudy>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<FieldOfStudyAndOrientation> FieldOfStudyAndOrientations => Set<FieldOfStudyAndOrientation>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfessorMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupStudyMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FieldOfStudyAndOrientationMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
