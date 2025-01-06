using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Authors;


namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take);
        Task<GetAuthorDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAuthorDto sizeDto);
        Task UpdateAuthorAsync(int id, UpdateAuthorDto sizeDTO);
        Task DeleteAuthorAsync(int id);
    }
}
