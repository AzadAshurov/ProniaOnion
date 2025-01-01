using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Colors
{
    public class GetColorDto(int Id, string Name, ICollection<ProductItemDto> Products);
}
