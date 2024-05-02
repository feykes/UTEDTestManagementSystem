using MediatR;
using System.Reflection;
using AutoMapper;
using TestManagementSystem.Application.Mappings.TestMap;
using Microsoft.Extensions.DependencyInjection;
using TestManagementSystem.Application.Mappings.ProjectMap;

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
