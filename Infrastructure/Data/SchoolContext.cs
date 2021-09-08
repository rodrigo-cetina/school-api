using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ScoreRecord> ScoreRecords { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}