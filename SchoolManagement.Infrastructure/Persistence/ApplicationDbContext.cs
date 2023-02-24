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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
