using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class FieldOfStudyAndOrientationMapping : IEntityTypeConfiguration<FieldOfStudyAndOrientation>
    {
        public void Configure(EntityTypeBuilder<FieldOfStudyAndOrientation> builder)
        {
            builder.ToTable("FieldOfStudyAndOrientations");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Department)
                   .WithMany(x => x.FieldOfStudyAndOrientations)
                   .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
