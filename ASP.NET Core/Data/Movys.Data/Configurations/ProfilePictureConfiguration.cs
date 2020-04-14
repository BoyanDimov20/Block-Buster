namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class ProfilePictureConfiguration : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(x => x.ProfilePicture)
                .HasForeignKey<ApplicationUser>(x => x.ProfilePictureId);
        }
    }
}
