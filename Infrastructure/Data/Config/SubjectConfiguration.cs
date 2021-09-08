using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.HasIndex(p => p.Title).IsUnique();
        }
    }
}