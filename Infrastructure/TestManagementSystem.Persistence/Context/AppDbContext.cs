using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Finding> Findings { get; set; }
        public DbSet<UploadedFile> Files { get; set; }
    }
}
