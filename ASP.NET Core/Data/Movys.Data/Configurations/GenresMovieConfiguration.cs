namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class GenresMovieConfiguration : IEntityTypeConfiguration<GenresMovie>
    {
        public void Configure(EntityTypeBuilder<GenresMovie> builder)
        {
            builder.HasKey(x => new { x.GenreId, x.MovieId });
        }
    }
}
