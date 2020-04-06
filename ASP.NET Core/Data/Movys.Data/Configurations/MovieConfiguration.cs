namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasMany(x => x.CastMembers)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder.HasMany(x => x.UserWatched)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder.HasMany(x => x.Genres)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            builder.HasMany(x => x.MediaUrls)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
