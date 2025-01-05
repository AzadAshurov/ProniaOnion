using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Configurations
{
    internal class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.HasKey(x => new { x.BlogId, x.TagId });
        }
    }
}
