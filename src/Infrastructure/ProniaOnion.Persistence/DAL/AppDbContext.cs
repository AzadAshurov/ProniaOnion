using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
