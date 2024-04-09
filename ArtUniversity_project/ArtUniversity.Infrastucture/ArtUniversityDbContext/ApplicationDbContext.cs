using ArtUnivercity.Domain.StudentDomain;
using ArtUniversity.Infrastucture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ArtUniversity.Infrastucture.EfCore.ArtUniversityDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
