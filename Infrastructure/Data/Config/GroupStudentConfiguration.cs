using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GroupStudentConfiguration : IEntityTypeConfiguration<GroupStudent>
    {
        public void Configure(EntityTypeBuilder<GroupStudent> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.GroupId).IsRequired();
            builder.Property(p => p.StudentId).IsRequired();
            builder.HasIndex(p => new { p.GroupId, p.StudentId }).IsUnique();
            builder.HasOne(b => b.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}