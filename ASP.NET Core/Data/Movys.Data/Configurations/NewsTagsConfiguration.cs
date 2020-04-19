namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class NewsTagsConfiguration : IEntityTypeConfiguration<NewsTags>
    {
        public void Configure(EntityTypeBuilder<NewsTags> builder)
        {
            builder.HasKey(x => new { x.NewsId, x.TagId });
        }
    }
}
