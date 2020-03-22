namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class TVShowsCastMemberConfiguration : IEntityTypeConfiguration<TVShowsCastMember>
    {
        public void Configure(EntityTypeBuilder<TVShowsCastMember> builder)
        {
            builder.HasKey(x => new { x.CastMemberId, x.TVShowId });
        }
    }
}
