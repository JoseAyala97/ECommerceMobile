using AutoMapper;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using ECommerceMobile.Application.Features.Products.Commands.UpdateProduct;
using ECommerceMobile.Domain.Entities;

namespace ECommerceMobile.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>()
                           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductVm>();
        }
    }
}
