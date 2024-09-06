using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Infrastructure.Persistence;
using ECommerceMobile.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceMobile.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ECommerceMobileDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );
            
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
