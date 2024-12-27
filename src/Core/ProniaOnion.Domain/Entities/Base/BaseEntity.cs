using System.ComponentModel.DataAnnotations;

namespace ProniaOnion.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DataType CreatedAt { get; set; }
        public DataType UpdatedAt { get; set; }


    }
}
