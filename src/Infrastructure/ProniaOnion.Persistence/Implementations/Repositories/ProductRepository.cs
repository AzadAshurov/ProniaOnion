
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.DAL;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
