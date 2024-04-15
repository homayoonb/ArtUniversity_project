using ArtUnivercity.Domain.ProfessorDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professors");
            builder.HasKey(e => e.Id);

            builder.HasMany(x => x.GroupStudies)
                   .WithOne(x => x.Professor)
                   .HasForeignKey(x => x.ProfessorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
