using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.DTOs.Products
{
    public record GetProductDto(
    int Id,
    decimal Price,
    string Name,
    string SKU,
    string Description,
    CategoryItemDto Category,
    IEnumerable<ColorItemDto> Colors,
    IEnumerable<SizeItemDto> Sizes,
    IEnumerable<TagItemDto> Tags
);
}
