using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.DAL;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
