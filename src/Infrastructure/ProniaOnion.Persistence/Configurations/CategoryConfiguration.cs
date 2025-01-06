﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder
               .Property(x => x.Surname)
               .IsRequired()
               .HasColumnType("varchar(100)");
        }
    }
}
