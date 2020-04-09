namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class CastMemberConfiguration : IEntityTypeConfiguration<CastMember>
    {
        public void Configure(EntityTypeBuilder<CastMember> builder)
        {
            builder.HasMany(x => x.Movies)
                .WithOne(x => x.CastMember)
                .HasForeignKey(x => x.CastMemberId);
        }
    }
}
