using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Application.Repositories.Finding;
using TestManagementSystem.Persistence.Configurations;
using TestManagementSystem.Persistence.Context;
using TestManagementSystem.Persistence.Repositories;
using TestManagementSystem.Persistence.Repositories.Finding;

namespace TestManagementSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ITestReadRepository, TestReadRepository>();
            services.AddScoped<ITestWriteRepository, TestWriteRepository>();
            services.AddScoped<IFindingReadRepository, FindingReadRepository>();
            services.AddScoped<IFindingWriteRepository, FindingWriteRepository>();
        }
    }
}
