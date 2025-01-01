using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService

    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<CategoryItemDto> categories = await _categoryRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<CategoryItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id, nameof(Category.Products));

            if (category == null) return null;


            // GetCategoryDto categoryDto = new(category.Id, category.Name, category.Products.Select(p => new ProductItemDto(p.Id, p.Name, p.SKU, p.Description)).ToList());
            var categoryDto = _mapper.Map<GetCategoryDto>(category);
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
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name))
                throw new Exception("Category exist");

            var category = _mapper.Map<Category>(categoryDto);

            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Not found");

            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name && c.Id == id))
                throw new Exception("Exists");
            category.UpdatedAt = DateTime.Now;
            category = _mapper.Map<Category>(categoryDto);
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
