using ArtUnivercity.Domain.DepartmentDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("DepartMents");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.GroupStudy)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.GroupStudyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
