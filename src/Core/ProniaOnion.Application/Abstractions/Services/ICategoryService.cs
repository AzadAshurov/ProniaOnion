using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task<bool> CreateCategoryAsync(CreateCategoryDto categoryDTO);
        Task UpdateCategoryAsync(int id, UpdateCategoryDto categoryDTO);
        Task DeleteCategoryAsync(int id);
    }
}
