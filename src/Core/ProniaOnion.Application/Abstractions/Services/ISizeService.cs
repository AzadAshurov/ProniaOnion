using ProniaOnion.Application.DTOs.Sizes;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ISizeService
    {
        Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take);
        Task<GetSizeDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSizeDto sizeDto);
        Task UpdateSizeAsync(int id, UpdateSizeDto sizeDTO);
        Task DeleteSizeAsync(int id);
    }
}
