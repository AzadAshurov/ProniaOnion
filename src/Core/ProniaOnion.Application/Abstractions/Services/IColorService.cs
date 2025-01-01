using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IColorService
    {
        Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take);
        Task<GetColorDto> GetByIdAsync(int id);
        Task CreateAsync(CreateColorDto colorDto);
        Task UpdateColorAsync(int id, UpdateColorDto colorDTO);
        Task DeleteColorAsync(int id);
    }
}
