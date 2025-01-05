using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.DTOs.Blogs
{
    public record GetBlogDto(int Id, string Name, AuthorItemDto AuthorItemDto,ICollection<TagItemDto> TagItemDtos);
}
