using MediatR;
using System.Reflection;
using AutoMapper;
using TestManagementSystem.Application.Mappings.TestMap;
using Microsoft.Extensions.DependencyInjection;

namespace TestManagementSystem.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new TestProfile()
                });
            });
        }
    }
}
