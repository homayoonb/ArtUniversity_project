using ArtUnivercity.Domain.StudentDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtUniversity.Infrastucture.EfCore.Mapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(500);
            builder.Property(x => x.FatherName).HasMaxLength(500);
            builder.Property(x => x.PersenalyCode).HasMaxLength(500);
            builder.Property(x => x.NationalCode).HasMaxLength(500);
            builder.Property(x => x.MobileNumber).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Address).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.KeyWord).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();


        }
    }
}
