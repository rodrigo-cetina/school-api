using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasOne(p => p.Person)
                .WithOne(p => p.Administrator)
                .HasForeignKey<Administrator>(p => p.Id);
        }
    }
}