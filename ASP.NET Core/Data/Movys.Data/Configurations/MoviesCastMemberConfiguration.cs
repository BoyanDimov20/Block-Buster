namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class MoviesCastMemberConfiguration : IEntityTypeConfiguration<MoviesCastMember>
    {
        public void Configure(EntityTypeBuilder<MoviesCastMember> builder)
        {
            builder.HasKey(x => new { x.CastMemberId, x.MovieId });
        }
    }
}
