using Assets.Application.Common.Interfaces;
using Assets.Infrastructure.Files;
using Assets.Infrastructure.Identity;
using Assets.Infrastructure.Persistence;
using Assets.Infrastructure.Services;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                    //options.Clients.AddSPA("angular", options => {
                    //    options.WithRedirectUri("http://localhost:4200/authentication/login-callback")
                    //        .WithLogoutRedirectUri("http://localhost:4200/")
                    //        .WithScopes(new string[] {
                    //            IdentityServerConstants.StandardScopes.OpenId,
                    //            IdentityServerConstants.StandardScopes.Profile,
                    //            "Assets.APIAPI"
                    //        })
                    //        .WithoutClientSecrets();
                    //});
                    //options.Clients.Add(new Client()
                    //{
                    //    ClientId = "angular",
                    //    ClientName = "Angular app",
                    //    RequireClientSecret = false,
                    //    AllowedGrantTypes = GrantTypes.Implicit,
                    //    AllowAccessTokensViaBrowser = true,
                    //    AllowedScopes = new List<string>() {
                    //        IdentityServerConstants.StandardScopes.OpenId,
                    //        IdentityServerConstants.StandardScopes.Profile,
                    //        "Assets.APIAPI"
                    //    },
                    //    // TODO: Configurable
                    //    AllowedCorsOrigins = new List<string>() { "http://localhost:4200" },
                    //    RedirectUris = new List<string>() { "http://localhost:4200/auth/oidc/callback" }
                    //});
                });

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddAuthentication()
                .AddIdentityServerJwt()
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = "d7b30aae-0a15-4f11-8bed-7f95340efd79";
                    options.ClientSecret = "rtEz27LL29Zq8~w-J1qQT0eDbU~1-2uuk_";
                });

            return services;
        }
    }
}
