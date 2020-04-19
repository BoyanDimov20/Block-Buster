namespace Movys.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Movys.Data.Models;

    public class TagsConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(x => x.News)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => x.TagId);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
