using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.HasIndex(p => p.Code).IsUnique();
            builder.HasOne(p => p.Person)
                .WithOne(p => p.Student)
                .HasForeignKey<Student>(p => p.Id);
        }
    }
}