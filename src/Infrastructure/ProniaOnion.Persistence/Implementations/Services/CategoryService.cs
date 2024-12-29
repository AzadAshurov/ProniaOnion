using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService

    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<CategoryItemDto> categories = await _categoryRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => new CategoryItemDto(x.Id, x.Name))
            .ToListAsync();
            return categories;

        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id, nameof(Category.Products));

            if (category == null) return null;

            GetCategoryDto categoryDto = new(category.Id, category.Name, category.Products.Select(p => new ProductItemDto(p.Id, p.Name, p.SKU, p.Description)).ToList());
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //    ProductsDTOs = category.Products?.Select(p => new GetProductDTO
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Price = p.Price
            //    }).ToList() ?? new List<GetProductDTO>()
            //};

            return categoryDto;
        }
        public async Task<bool> CreateCategoryAsync(CreateCategoryDto categoryDTO)
        {
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDTO.Name))
                return false;

            await _categoryRepository.AddAsync(new Category
            {
                Name = categoryDTO.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            });

            await _categoryRepository.SaveChangesAsync();

            return true;
        }

        public async Task UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Not found");

            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name && c.Id == id))
                throw new Exception("Exists");
            category.UpdatedAt = DateTime.Now;
            category.Name = categoryDto.Name;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                throw new Exception("Not found");

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }

    }
}
