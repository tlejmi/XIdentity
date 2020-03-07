using System;
using System.Collections.Generic;
using HealthChecks.UI.Client;
using Luttra.XIdentity.Admin.Api.Configuration;
using Luttra.XIdentity.Admin.Api.Configuration.Authorization;
using Luttra.XIdentity.Admin.Api.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Skoruba.AuditLogging.EntityFramework.Entities;
using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity;
using Luttra.XIdentity.BusinessLogic.Identity.Extensions;
using Luttra.XIdentity.EntityFramework.Shared.DbContexts;
using Luttra.XIdentity.EntityFramework.Shared.Entities.Identity;
using Luttra.XIdentity.Admin.Api.Helpers;
using Luttra.XIdentity.Admin.Api.Mappers;
using Luttra.XIdentity.Admin.Api.Resources;

namespace Luttra.XIdentity.Admin.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var adminApiConfiguration = Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
            services.AddSingleton(adminApiConfiguration);

            // Add DbContexts
            RegisterDbContexts(services);

            services.AddScoped<ControllerExceptionFilterAttribute>();
            services.AddScoped<IApiErrorResources, ApiErrorResources>();

            // Add authentication services
            RegisterAuthentication(services);

            // Add authorization services
            RegisterAuthorization(services);

            var profileTypes = new HashSet<Type>
            {
                typeof(IdentityMapperProfile<RoleDto<Guid>, Guid, UserRolesDto<RoleDto<Guid>, Guid, Guid>, Guid, UserClaimsDto<Guid>, UserClaimDto<Guid>, UserProviderDto<Guid>, UserProvidersDto<Guid>, UserChangePasswordDto<Guid>,RoleClaimDto<Guid>, RoleClaimsDto<Guid>>)
            };

            services.AddAdminAspNetIdentityServices<AdminIdentityDbContext, IdentityServerPersistedGrantDbContext, UserDto<Guid>, Guid, RoleDto<Guid>, Guid, Guid, Guid,
                XIdentityUser, XIdentityRole, Guid, UserXIdentityUserClaim, UserXIdentityUserRole,
                UserXIdentityUserLogin, UserXIdentityRoleClaim, UserXIdentityUserToken,
                UsersDto<UserDto<Guid>, Guid>, RolesDto<RoleDto<Guid>, Guid>, UserRolesDto<RoleDto<Guid>, Guid, Guid>,
                UserClaimsDto<Guid>, UserProviderDto<Guid>, UserProvidersDto<Guid>, UserChangePasswordDto<Guid>,
                RoleClaimsDto<Guid>, UserClaimDto<Guid>, RoleClaimDto<Guid>>(profileTypes);

            services.AddAdminServices<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext>();

            services.AddAdminApiCors(adminApiConfiguration);

            services.AddMvcServices<UserDto<Guid>, Guid, RoleDto<Guid>, Guid, Guid, Guid,
                XIdentityUser, XIdentityRole, Guid, UserXIdentityUserClaim, UserXIdentityUserRole,
                UserXIdentityUserLogin, UserXIdentityRoleClaim, UserXIdentityUserToken,
                UsersDto<UserDto<Guid>, Guid>, RolesDto<RoleDto<Guid>, Guid>, UserRolesDto<RoleDto<Guid>, Guid, Guid>,
                UserClaimsDto<Guid>, UserProviderDto<Guid>, UserProvidersDto<Guid>, UserChangePasswordDto<Guid>,
                RoleClaimsDto<Guid>>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(adminApiConfiguration.ApiVersion, new OpenApiInfo { Title = adminApiConfiguration.ApiName, Version = adminApiConfiguration.ApiVersion , Contact = new OpenApiContact()
                {
                    Email = "tarek.lejmi@gmail.com",
                    Name = "Tarek Lejmi"
                }, Description = "Luttra XIdentity Administration Manager"});

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{adminApiConfiguration.IdentityServerBaseUrl}/connect/authorize"),
                            Scopes = new Dictionary<string, string> {
                                { adminApiConfiguration.OidcApiName, adminApiConfiguration.ApiName }
                            }
                        }
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);

            services.AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext>(Configuration, adminApiConfiguration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdminApiConfiguration adminApiConfiguration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{adminApiConfiguration.ApiBaseUrl}/swagger/v1/swagger.json", adminApiConfiguration.ApiName);

                c.OAuthClientId(adminApiConfiguration.OidcSwaggerUIClientId);
                c.OAuthAppName(adminApiConfiguration.ApiName);
            });

            app.UseRouting();
            UseAuthentication(app);
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }

        public virtual void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext>(Configuration);
        }

        public virtual void RegisterAuthentication(IServiceCollection services)
        {
            var adminApiConfiguration = Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
            services.AddApiAuthentication<AdminIdentityDbContext, XIdentityUser, XIdentityRole>(adminApiConfiguration);
        }

        public virtual void RegisterAuthorization(IServiceCollection services)
        {
            services.AddAuthorizationPolicies();
        }

        public virtual void UseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}






