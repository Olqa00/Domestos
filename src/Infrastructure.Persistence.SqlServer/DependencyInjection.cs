namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, IProductRepository>();
    }
}