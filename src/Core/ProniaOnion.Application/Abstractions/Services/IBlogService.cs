using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogItemDto>> GetAllAsync(int page, int take);
        Task<GetBlogDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBlogDto blogDto);
        Task UpdateBlogAsync(int id, UpdateBlogDto blogDTO);
        Task DeleteBlogAsync(int id);
    }
}
