﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Luttra.XIdentity.BusinessLogic.Identity.Extensions;
using Luttra.XIdentity.BusinessLogic.Identity.Mappers.Configuration;
using Luttra.XIdentity.BusinessLogic.Identity.Resources;
using Luttra.XIdentity.BusinessLogic.Identity.Services;
using Luttra.XIdentity.BusinessLogic.Identity.Services.Interfaces;
using Luttra.XIdentity.EntityFramework.Identity.Repositories;
using Luttra.XIdentity.EntityFramework.Identity.Repositories.Interfaces;
using Luttra.XIdentity.EntityFramework.Interfaces;

// ReSharper disable once CheckNamespace
namespace Luttra.XIdentity.BusinessLogic.Identity.Extensions
{
    public static class AdminServicesExtensions
    {
        public static IMapperConfigurationBuilder AddAdminAspNetIdentityMapping(this IServiceCollection services)
        {
            var builder = new MapperConfigurationBuilder();

            services.AddSingleton<IConfigurationProvider>(sp => new MapperConfiguration(cfg =>
            {
                foreach (var profileType in builder.ProfileTypes)
                    cfg.AddProfile(profileType);
            }));

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            return builder;
        }

        public static IServiceCollection AddAdminAspNetIdentityServices<TIdentityDbContext, TPersistedGrantDbContext, TUser>(
            this IServiceCollection services)
            where TIdentityDbContext : IdentityDbContext<TUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TUser : IdentityUser
        {
            return services.AddAdminAspNetIdentityServices<TIdentityDbContext, TPersistedGrantDbContext, UserDto<string>, string, RoleDto<string>, string, string,
                string, TUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>,
                UsersDto<UserDto<string>, string>, RolesDto<RoleDto<string>, string>, UserRolesDto<RoleDto<string>, string, string>,
                UserClaimsDto<string>, UserProviderDto<string>, UserProvidersDto<string>, UserChangePasswordDto<string>,
                RoleClaimsDto<string>, UserClaimDto<string>, RoleClaimDto<string>>();
        }

        public static IServiceCollection AddAdminAspNetIdentityServices<TAdminDbContext, TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey,
            TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto,
            TUserClaimDto, TRoleClaimDto>(
                this IServiceCollection services)
            where TAdminDbContext :
            IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>,
            IAdminPersistedGrantDbContext
            where TUserDto : UserDto<TUserDtoKey>
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
            where TUserClaim : IdentityUserClaim<TKey>
            where TUserRole : IdentityUserRole<TKey>
            where TUserLogin : IdentityUserLogin<TKey>
            where TRoleClaim : IdentityRoleClaim<TKey>
            where TUserToken : IdentityUserToken<TKey>
            where TRoleDto : RoleDto<TRoleDtoKey>
            where TUsersDto : UsersDto<TUserDto, TUserDtoKey>
            where TRolesDto : RolesDto<TRoleDto, TRoleDtoKey>
            where TUserRolesDto : UserRolesDto<TRoleDto, TUserDtoKey, TRoleDtoKey>
            where TUserClaimsDto : UserClaimsDto<TUserDtoKey>
            where TUserProviderDto : UserProviderDto<TUserDtoKey>
            where TUserProvidersDto : UserProvidersDto<TUserDtoKey>
            where TUserChangePasswordDto : UserChangePasswordDto<TUserDtoKey>
            where TRoleClaimsDto : RoleClaimsDto<TRoleDtoKey>
            where TUserClaimDto : UserClaimDto<TUserDtoKey>
            where TRoleClaimDto : RoleClaimDto<TRoleDtoKey>
        {

            return services.AddAdminAspNetIdentityServices<TAdminDbContext, TAdminDbContext, TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey,
                TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto>();
        }

        public static IServiceCollection AddAdminAspNetIdentityServices<TIdentityDbContext, TPersistedGrantDbContext, TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                    TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                    TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto>(
                        this IServiceCollection services)
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TIdentityDbContext : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
            where TUserDto : UserDto<TUserDtoKey>
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
            where TUserClaim : IdentityUserClaim<TKey>
            where TUserRole : IdentityUserRole<TKey>
            where TUserLogin : IdentityUserLogin<TKey>
            where TRoleClaim : IdentityRoleClaim<TKey>
            where TUserToken : IdentityUserToken<TKey>
            where TRoleDto : RoleDto<TRoleDtoKey>
            where TUsersDto : UsersDto<TUserDto, TUserDtoKey>
            where TRolesDto : RolesDto<TRoleDto, TRoleDtoKey>
            where TUserRolesDto : UserRolesDto<TRoleDto, TUserDtoKey, TRoleDtoKey>
            where TUserClaimsDto : UserClaimsDto<TUserDtoKey>
            where TUserProviderDto : UserProviderDto<TUserDtoKey>
            where TUserProvidersDto : UserProvidersDto<TUserDtoKey>
            where TUserChangePasswordDto : UserChangePasswordDto<TUserDtoKey>
            where TRoleClaimsDto : RoleClaimsDto<TRoleDtoKey>
            where TUserClaimDto : UserClaimDto<TUserDtoKey>
            where TRoleClaimDto : RoleClaimDto<TRoleDtoKey>
        {
            return AddAdminAspNetIdentityServices<TIdentityDbContext, TPersistedGrantDbContext, TUserDto, TUserDtoKey,
                TRoleDto, TRoleDtoKey, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin,
                TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto,
                TRoleClaimDto>(services, null);
        }

        public static IServiceCollection AddAdminAspNetIdentityServices<TIdentityDbContext, TPersistedGrantDbContext, TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                    TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                    TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto>(
                        this IServiceCollection services, HashSet<Type> profileTypes)
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TIdentityDbContext : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
            where TUserDto : UserDto<TUserDtoKey>
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
            where TUserClaim : IdentityUserClaim<TKey>
            where TUserRole : IdentityUserRole<TKey>
            where TUserLogin : IdentityUserLogin<TKey>
            where TRoleClaim : IdentityRoleClaim<TKey>
            where TUserToken : IdentityUserToken<TKey>
            where TRoleDto : RoleDto<TRoleDtoKey>
            where TUsersDto : UsersDto<TUserDto, TUserDtoKey>
            where TRolesDto : RolesDto<TRoleDto, TRoleDtoKey>
            where TUserRolesDto : UserRolesDto<TRoleDto, TUserDtoKey, TRoleDtoKey>
            where TUserClaimsDto : UserClaimsDto<TUserDtoKey>
            where TUserProviderDto : UserProviderDto<TUserDtoKey>
            where TUserProvidersDto : UserProvidersDto<TUserDtoKey>
            where TUserChangePasswordDto : UserChangePasswordDto<TUserDtoKey>
            where TRoleClaimsDto : RoleClaimsDto<TRoleDtoKey>
            where TUserClaimDto : UserClaimDto<TUserDtoKey>
            where TRoleClaimDto : RoleClaimDto<TRoleDtoKey>
        {
            //Repositories
            services.AddTransient<IIdentityRepository<TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>, IdentityRepository<TIdentityDbContext, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>>();
            services.AddTransient<IPersistedGrantAspNetIdentityRepository, PersistedGrantAspNetIdentityRepository<TIdentityDbContext, TPersistedGrantDbContext, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>>();
          
            //Services
            services.AddTransient<IIdentityService<TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto>, 
                IdentityService<TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUserKey, TRoleKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                    TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                    TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto>>();
            services.AddTransient<IPersistedGrantAspNetIdentityService, PersistedGrantAspNetIdentityService>();
            
            //Resources
            services.AddScoped<IIdentityServiceResources, IdentityServiceResources>();
            services.AddScoped<IPersistedGrantAspNetIdentityServiceResources, PersistedGrantAspNetIdentityServiceResources>();

            //Register mapping
            services.AddAdminAspNetIdentityMapping()
                .UseIdentityMappingProfile<TUserDto, TUserDtoKey, TRoleDto, TRoleDtoKey, TUser, TRole, TKey, TUserClaim,
                    TUserRole, TUserLogin, TRoleClaim, TUserToken,
                    TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                    TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto,
                    TRoleClaimDto>()
                .AddProfilesType(profileTypes);

            return services;
        }
    }
}
