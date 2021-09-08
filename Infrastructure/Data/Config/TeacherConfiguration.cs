using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.HasIndex(p => p.Code).IsUnique();
            builder.HasOne(p => p.Person)
                .WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(p => p.Id);
        }
    }
}