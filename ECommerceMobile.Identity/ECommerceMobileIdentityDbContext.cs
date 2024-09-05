using ECommerceMobile.Identity.Configurations;
using ECommerceMobile.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMobile.Identity
{
    public class ECommerceMobileIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceMobileIdentityDbContext(DbContextOptions<ECommerceMobileIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}
