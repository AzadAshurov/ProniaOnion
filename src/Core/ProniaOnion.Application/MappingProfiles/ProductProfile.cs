using AutoMapper;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile : Profile

    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ForMember(x => x.ProductColors, opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci })));
            CreateMap<Product, GetProductDto>()
    .ForCtorParam(
        nameof(GetProductDto.Colors),
        opt => opt.MapFrom(
            p => p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name)).ToList()
        )
    );



            CreateMap<UpdateProductDto, Product>()
    .ForMember(
        p => p.Id,
        opt => opt.Ignore()
    )
    .ForMember(
        p => p.ProductColors,
        opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci }))
    );
        }
    }
}
