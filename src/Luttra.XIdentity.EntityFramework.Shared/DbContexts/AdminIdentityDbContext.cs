using System;
using Luttra.XIdentity.EntityFramework.Shared.Constants;
using Luttra.XIdentity.EntityFramework.Shared.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Luttra.XIdentity.EntityFramework.Shared.DbContexts
{
    public class AdminIdentityDbContext : IdentityDbContext<XIdentityUser, XIdentityRole, Guid, XIdentityUserClaim, XIdentityUserRole, XIdentityUserLogin, XIdentityRoleClaim, XIdentityUserToken>
    {
        public AdminIdentityDbContext(DbContextOptions<AdminIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentityContext(builder);
        }

        private void ConfigureIdentityContext(ModelBuilder builder)
        {
            builder.HasDefaultSchema("XIdentity"); 
            builder.Entity<XIdentityRole>().ToTable(TableConsts.IdentityRoles);
            builder.Entity<XIdentityRoleClaim>().ToTable(TableConsts.IdentityRoleClaims);
            builder.Entity<XIdentityUserRole>().ToTable(TableConsts.IdentityUserRoles);

            builder.Entity<XIdentityUser>().ToTable(TableConsts.IdentityUsers);
            builder.Entity<XIdentityUserLogin>().ToTable(TableConsts.IdentityUserLogins);
            builder.Entity<XIdentityUserClaim>().ToTable(TableConsts.IdentityUserClaims);
            builder.Entity<XIdentityUserToken>().ToTable(TableConsts.IdentityUserTokens);
        }
    }
}





