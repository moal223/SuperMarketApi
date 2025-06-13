using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using supermarket.domain.Entities;
using supermarket.ef.Configurations;

namespace supermarket.ef.Data
{
    public class SqlServerDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove unnecessary tables while keeping Users and Roles
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();

            builder.ApplyConfiguration(new ProductConfiguration());
        }
        
        public DbSet<Product> Products { get; set; }
    }
}