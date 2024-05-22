using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestManagementSystem.Application.Mappings.ProjectMap;
using TestManagementSystem.Application.Mappings.TestMap;

namespace TestManagementSystem.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new TestProfile(),
                    new ProjectProfile()
                });
            });
        }
    }
}
