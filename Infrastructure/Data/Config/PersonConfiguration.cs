using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Role).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
        }
    }
}