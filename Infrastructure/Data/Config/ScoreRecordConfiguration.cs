using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ScoreRecordConfiguration : IEntityTypeConfiguration<ScoreRecord>
    {
        public void Configure(EntityTypeBuilder<ScoreRecord> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.StudentId).IsRequired();
            builder.Property(p => p.GroupId).IsRequired();
            builder.Property(p => p.Score).HasColumnType("decimal(3,2)").IsRequired();
            builder.HasIndex(p => new { p.StudentId, p.GroupId }).IsUnique();
            builder.HasOne(b => b.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}