using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestManagementSystem.Domain.Entities;
using TestManagementSystem.Domain.Entities.Identity;

namespace TestManagementSystem.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Finding> Findings { get; set; }
        public DbSet<UploadedFile> Files { get; set; }
    }
}
