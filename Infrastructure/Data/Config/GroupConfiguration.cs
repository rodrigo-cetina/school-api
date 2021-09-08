using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CareerId).IsRequired();
            builder.Property(p => p.SubjectId).IsRequired();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(100);
            builder.Property(p => p.TeacherId).IsRequired();
            builder.HasIndex(p => new { p.CareerId, p.SubjectId, p.Code }).IsUnique();
            builder.HasOne(b => b.Career)
                .WithMany()
                .HasForeignKey(p => p.CareerId);
            builder.HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(p => p.SubjectId);
            builder.HasOne(t => t.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId);
        }
    }
}