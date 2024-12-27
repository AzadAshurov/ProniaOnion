using ProniaOnion.Domain.Entities.Base;

namespace ProniaOnion.Domain.Entities
{
    public class Color : BaseNameableEntity
    {
        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
