using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Sizes
{
    public class GetSizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductItemDto> Products { get; set; } = new List<ProductItemDto>();
    }
}
