// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using BlogOS.Web.Models; // Project modelinizin namespace'ini ekleyin (örn: using YourProjectName.Models;)

namespace BlogOS.Web.Data // Projenizin namespace'ine göre ayarlayın (örn: namespace YourProjectName.Data)
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}