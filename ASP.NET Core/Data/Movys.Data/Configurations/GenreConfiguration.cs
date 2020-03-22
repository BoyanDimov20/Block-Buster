namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasMany(x => x.TVShows)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);

            builder.HasMany(x => x.Movies)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
