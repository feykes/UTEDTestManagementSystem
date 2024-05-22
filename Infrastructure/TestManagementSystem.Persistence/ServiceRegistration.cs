using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TestManagementSystem.Application.Abstractions;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Domain.Entities.Identity;
using TestManagementSystem.Persistence.Context;
using TestManagementSystem.Persistence.Repositories;
using TestManagementSystem.Persistence.Repositories.Services;

namespace TestManagementSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });
            #endregion

            #region Identity
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();
            #endregion

            #region JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer("Admin", options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidateAudience = true, //Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanýcý belirlediðimiz deðerdir. -> www.bilmemne.com
                       ValidateIssuer = true, //Oluþturulacak token deðerini kimin daðýttýný ifade edeceðimiz alandýr. -> www.myapi.com
                       ValidateLifetime = true, //Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
                       ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden suciry key verisinin doðrulanmasýdýr.

                       ValidAudience = configuration.GetConnectionString("Token:Audience"),
                       ValidIssuer = configuration.GetConnectionString("Token:Issuer"),
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetConnectionString("Token:SecurityKey"))),
                       LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

                       NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.
                   };
               });

            #endregion

            #region IOC
            services.AddScoped<ITestReadRepository, TestReadRepository>();
            services.AddScoped<ITestReadRepository, TestReadRepository>();
            services.AddScoped<ITestWriteRepository, TestWriteRepository>();
            services.AddScoped<IFindingReadRepository, FindingReadRepository>();
            services.AddScoped<IFindingWriteRepository, FindingWriteRepository>();
            services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
            services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();

            services.AddScoped<ITokenHandler, TestManagementSystem.Persistence.Repositories.Services.TokenHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

        }
    }
}
