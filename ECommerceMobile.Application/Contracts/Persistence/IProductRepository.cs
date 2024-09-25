using ECommerceMobile.Domain.Entities;

namespace ECommerceMobile.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
