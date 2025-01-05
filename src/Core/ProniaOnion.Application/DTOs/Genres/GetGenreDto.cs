
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.DTOs.Categories
{
    public record GetGenreDto(int Id, string Name, ICollection<BlogItemDto> Blogs);
    
}
