namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class MoviesUserConfiguration : IEntityTypeConfiguration<MoviesUser>
    {
        public void Configure(EntityTypeBuilder<MoviesUser> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.UserId });
        }
    }
}
