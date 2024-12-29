
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Categories
{
    public record GetCategoryDto(int Id, string Name, ICollection<ProductItemDto> Products);

}
