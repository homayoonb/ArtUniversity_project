using ArtUnivercity.Domain.GroupStudyDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class GroupStudyMapping : IEntityTypeConfiguration<GroupStudy>
    {
        public void Configure(EntityTypeBuilder<GroupStudy> builder)
        {
            builder.ToTable("GroupStudies");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Professor)
                   .WithMany(x => x.GroupStudies)
                   .HasForeignKey(x => x.ProfessorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.GroupStudies)
                   .HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
