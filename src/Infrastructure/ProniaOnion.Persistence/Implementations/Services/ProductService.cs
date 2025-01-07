using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
            var prod = _mapper.Map<GetProductDto>( await _productRepository.GetByIdAsync(id, "Category","ProductColors", "ProductColors.Color"));
            return prod;
        }
    }
}
