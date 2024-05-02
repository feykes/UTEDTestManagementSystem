using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Persistence.Configurations;
using TestManagementSystem.Persistence.Context;
using TestManagementSystem.Persistence.Repositories;

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
            services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
            services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();
        }
    }
}
