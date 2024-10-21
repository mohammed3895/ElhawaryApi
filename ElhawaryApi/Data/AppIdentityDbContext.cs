
using Microsoft.AspNetCore.Identity;

namespace ElhawaryApi.Data
{
    public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ownerRoleId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();

            var roles = new List<IdentityRole>{
                new ()
                {
                    Id = ownerRoleId,
                    ConcurrencyStamp = ownerRoleId,
                    Name = "Owner",
                    NormalizedName  = "Owner",
                },
                new ()
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName  = "Admin",
                },
                new ()
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName  = "User",
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
