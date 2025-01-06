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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
