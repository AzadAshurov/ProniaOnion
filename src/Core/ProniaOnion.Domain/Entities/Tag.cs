
using ProniaOnion.Domain.Entities.Base;

namespace ProniaOnion.Domain.Entities
{
    public class Tag : BaseNameableEntity
    {
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
