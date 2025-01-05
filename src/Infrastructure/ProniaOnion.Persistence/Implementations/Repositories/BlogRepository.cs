using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.DAL;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
