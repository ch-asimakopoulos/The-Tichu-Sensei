using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Infrastructure.Identity;
using TichuSensei.Infrastructure.Persistence;
using TichuSensei.Infrastructure.Services;

namespace TichuSensei.Infrastructure
{
    public static class DependencyInjection
    {

        private static IServiceCollection AddPostgreSQLDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseSnakeCaseNamingConvention()
                );
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgreSQLDbContext(configuration)
                     .AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>())
                     .AddScoped<IDomainEventService, DomainEventService>()
                     .AddDefaultIdentity<ApplicationUser>()
                     .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>()
                    .AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            return services;
        }
    }
}