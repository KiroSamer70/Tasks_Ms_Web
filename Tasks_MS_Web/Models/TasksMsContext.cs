using Microsoft.EntityFrameworkCore;
namespace Tasks_MS_Web.Models
{
    public class TasksMsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=FS-COMLAB3-PC12\\MSSQLSERVER2;Initial Catalog=TasksMsDB ;User ID=sa; Password=FIATS@2024; Trust Server Certificate=True ");                                                     
        }

        public DbSet<Tasks> Tasks {get; set;}
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

    }
}
