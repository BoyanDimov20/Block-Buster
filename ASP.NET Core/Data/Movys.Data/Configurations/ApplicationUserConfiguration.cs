namespace Movys.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
        {
            appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser.HasMany(x => x.MovieWatchList)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            appUser.HasMany(x => x.Reviews)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            appUser.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
