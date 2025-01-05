
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.DTOs.Categories
{
    public record GetCategoryDto(int Id, string Name, ICollection<ProductItemDto> Products);
    
}
