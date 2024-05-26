using ArtUnivercity.Domain.CourseDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.FieldOfStudyAndOrientations)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.FieldOfStudyAndOrientationId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
