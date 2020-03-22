namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class TVShowConfiguration : IEntityTypeConfiguration<TVShow>
    {
        public void Configure(EntityTypeBuilder<TVShow> builder)
        {
            builder.HasMany(x => x.CastMembers)
                .WithOne(x => x.TVShow)
                .HasForeignKey(x => x.TVShowId);

            builder.HasMany(x => x.Genres)
                .WithOne(x => x.TVShow)
                .HasForeignKey(x => x.TVShowId);
        }
    }
}
