namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Domestos.Infrastructure.Persistence.PostgreSQL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}