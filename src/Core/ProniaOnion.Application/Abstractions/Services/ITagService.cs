using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTagDto tagDto);
        Task UpdateTagAsync(int id, UpdateTagDto tagDTO);
        Task DeleteTagAsync(int id);
    }
}
