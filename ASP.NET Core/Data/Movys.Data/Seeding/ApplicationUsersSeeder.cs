namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Movys.Data.Models;

    public class ApplicationUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any())
            {
                PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

                string userId = Guid.NewGuid().ToString();
                var user = new ApplicationUser
                {
                    Id = userId,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@abv.bg",
                    NormalizedEmail = "ADMIN@ABV.BG",
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");
                var adminRoleId = dbContext.Roles.Select(x => x.Id).First();
                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();

                var userRole = new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = userId,
                };

                await dbContext.UserRoles.AddAsync(userRole);
            }
        }
    }
}
