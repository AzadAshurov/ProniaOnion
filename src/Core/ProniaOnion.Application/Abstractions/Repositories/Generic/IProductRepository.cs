using ProniaOnion.Domain.Entities;
using ProniaOnion.Domain.Entities.Base;

namespace ProniaOnion.Application.Abstractions.Repositories.Generic
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<T>> GetManyToManyEntities<T>(ICollection<int> ids) where T : BaseEntity;
    }
}
