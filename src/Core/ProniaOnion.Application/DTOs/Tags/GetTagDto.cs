using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Tags
{
    public class GetTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductItemDto> Products { get; set; } = new List<ProductItemDto>();
    }
}
