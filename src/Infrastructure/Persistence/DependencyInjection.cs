namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Domestos.Infrastructure.Persistence.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


internal static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();

        return services;
    }
}
