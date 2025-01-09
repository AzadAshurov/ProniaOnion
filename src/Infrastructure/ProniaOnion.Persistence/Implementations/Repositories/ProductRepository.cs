
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Domain.Entities.Base;
using ProniaOnion.Persistence.DAL;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<T>> GetManyToManyEntities<T>(ICollection<int> ids) where T : BaseEntity
        {
            return await _context.Set<T>()
                                 .Where(c => ids.Contains(c.Id))
                                 .ToListAsync();
        }
    }
}
