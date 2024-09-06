using AutoMapper;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using ECommerceMobile.Domain.Entities;

namespace ECommerceMobile.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductVm>();
        }
    }
}
