using ProniaOnion.Application.DTOs.Genres;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take);
        Task<GetGenreDto> GetByIdAsync(int id);
        Task CreateAsync(CreateGenreDto genreDto);
        Task UpdateGenreAsync(int id, UpdateGenreDto genreDTO);
        Task DeleteGenreAsync(int id);
    }
}
