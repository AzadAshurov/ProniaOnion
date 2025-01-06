
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.DTOs.Authors
{
    public record GetAuthorDto(int Id, string Name, string Surname, string ProfileImage, ICollection<BlogItemDto> Blogs);
    
}
