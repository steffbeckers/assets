using Assets.Application.Common.Interfaces;
using Assets.Infrastructure.Files;
using Assets.Infrastructure.Identity;
using Assets.Infrastructure.Persistence;
using Assets.Infrastructure.Services;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SQLServer"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                //.AddInMemoryApiResources(new List<ApiResource>() {
                //    new ApiResource()
                //    {
                //        Name = IdentityServerConstants.LocalApi.ScopeName,
                //        DisplayName = "Assets API"
                //    }
                //})
                .AddApiAuthorization<User, ApplicationDbContext>(options =>
                {
                    options.Clients.Add(new Client()
                    {
                        ClientId = "generic",
                        ClientName = "Generic",
                        RequireClientSecret = false,
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials
                    });
                    options.Clients.Add(new Client()
                    {
                        ClientId = "swagger",
                        ClientName = "Swagger",
                        ClientSecrets = new List<Secret>() { new Secret("Sw@ggerrr".Sha256()) },
                        AllowedGrantTypes = GrantTypes.ClientCredentials
                    });
                });

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
