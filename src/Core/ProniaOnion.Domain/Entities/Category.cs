using ProniaOnion.Domain.Entities.Base;

namespace ProniaOnion.Domain.Entities
{
    public class Category : BaseNameableEntity
    {
        //Relation
        public ICollection<Product> Products { get; set; }
    }
}
