namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class GenresTVShowConfiguration : IEntityTypeConfiguration<GenresTVShow>
    {
        public void Configure(EntityTypeBuilder<GenresTVShow> builder)
        {
            builder.HasKey(x => new { x.GenreId, x.TVShowId });
        }
    }
}
