using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Genres;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Abstractions.Services
{
   public interface IProductService
    {
     
            Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take);
            Task<GetProductDto> GetByIdAsync(int id);
            //Task CreateAsync(CreateGenreDto genreDto);
            //Task UpdateAsync(int id, UpdateGenreDto genreDTO);
            //Task DeleteAsync(int id);
        
    }
}
