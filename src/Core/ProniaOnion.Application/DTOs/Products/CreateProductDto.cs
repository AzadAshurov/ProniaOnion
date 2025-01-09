namespace ProniaOnion.Application.DTOs.Products
{
    public record CreateProductDto
    (decimal Price,
            string Name,
            string SKU,
            string Description,
            int CategoryId,
            ICollection<int> ColorIds,
             ICollection<int> SizeIds,
              ICollection<int> TagIds
            );

}
