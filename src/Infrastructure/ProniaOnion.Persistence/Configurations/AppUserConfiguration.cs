
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities.Identity;


namespace ProniaOnion.Persistence.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasColumnType("varchar(40)");
            builder.Property(u => u.Surname).IsRequired().HasColumnType("varchar(40)");
        }
    }
}
