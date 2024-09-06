using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Domain.Entities;
using ECommerceMobile.Infrastructure.Persistence;

namespace ECommerceMobile.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ECommerceMobileDbContext context) : base(context)
        {
        }
    }
}
