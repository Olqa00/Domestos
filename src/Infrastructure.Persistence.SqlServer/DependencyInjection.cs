using Domestos.Infrastructure.Persistence.SqlServer.Services;

namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Domestos.Infrastructure.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductReadService, ProductReadService>();
    }
}