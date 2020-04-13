namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId);
        }
    }
}
