using MySql.Data.EntityFramework;
using SchoolManagement.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Persistence
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("SchoolManagementDb") { }

        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentAnswer> AssignmentAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTeacher>()
                .HasRequired<User>(c => c.Teacher)
                .WithMany(u => u.CourseTeachers)
                .HasForeignKey<int>(c => c.TeacherId);

            modelBuilder.Entity<CourseStudent>()
                .HasRequired<User>(c => c.Student)
                .WithMany(u => u.CourseStudents)
                .HasForeignKey<int>(c => c.StudentId);

            modelBuilder.Entity<AssignmentAnswer>()
                .HasRequired<User>(a => a.Student)
                .WithMany(u => u.AssignmentAnswers)
                .HasForeignKey<int>(a => a.StudentId);
        }
    }
}
