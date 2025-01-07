using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Domain.Entities.Base;
namespace ProniaOnion.Persistence.Common
{
    internal static class GlobalQueryFilter
    {



        public static void ApplyFilter<T>(this ModelBuilder modelBuilder) where T : BaseEntity, new()
        {
            modelBuilder.Entity<Category>().HasQueryFilter(c => c.IsDeleted == false);
        }
        public static void ApplyQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyFilter<Category>();
        }


    }
}
