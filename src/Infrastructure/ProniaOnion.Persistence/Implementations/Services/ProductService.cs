using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,ICategoryRepository categoryRepository,IColorRepository colorRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDto productDto)
        {
            if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                throw new Exception("Category does not exist");

            var colorEntities = await _productRepository.GetManyToManyEntities<Color>(productDto.ColorIds);

            if (colorEntities.Count() != productDto.ColorIds.Distinct().Count())
                throw new Exception("Color id is wrong");

            await _productRepository.AddAsync(_mapper.Map<Product>(productDto));
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take)
        {
            var products = _mapper.Map<IEnumerable<ProductItemDto>>(
                await _productRepository.GetAll(skip: (page - 1) * take, take: take).ToListAsync()
            );
            return products;
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            var prod = _mapper.Map<GetProductDto>(await _productRepository.GetByIdAsync(id, "Category", "ProductColors", "ProductColors.Color"));
            return prod;
        }
        public async Task UpdateAsync(int id, UpdateProductDto productDto)
        {
            Product product = await _productRepository.GetByIdAsync(id, "ProductColors");

            if (productDto.CategoryId != product.CategoryId)
            {
                 if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                {
                    throw new Exception("Category does not exist");
                }
            }

            ICollection<int> createItems = productDto.ColorIds
                .Where(cId => !product.ProductColors.Any(pc => pc.ColorId == cId))
                .ToList();

            var colorEntities = await _productRepository.GetManyToManyEntities<Color>(createItems);
              

            if (colorEntities.Count() != createItems.Distinct().Count())
            {
                throw new Exception("One or more Color Id is wrong");
            }
            _productRepository.Update(_mapper.Map(productDto, product));
            await _productRepository.SaveChangesAsync();
        }
    }
}
