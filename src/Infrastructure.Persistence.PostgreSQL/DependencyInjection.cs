namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Domestos.Infrastructure.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domestos.Infrastructure.Persistence.PostgreSQL.Services;

public static class DependencyInjection
{
    public static void AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductReadService, ProductReadService>();
    }
}