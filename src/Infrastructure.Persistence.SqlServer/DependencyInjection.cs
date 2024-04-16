using Domestos.Persistence.SqlServer.Services;

namespace Domestos.Persistence;

using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using Domestos.Domain.Interfaces;
using Domestos.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new SqlServerOptions();
        var connectionString = configuration.GetConnectionString("DomestosConnection");
        CheckConnection(connectionString);


        options.ConnectionString = connectionString;
        services.AddSingleton(options);

        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductReadService, ProductReadService>();
    }

    private static void CheckConnection(string connectionString)
    {
        var query = "SELECT @@VERSION";

        using var connection = new SqlConnection(connectionString);
        connection.ExecuteScalar(query);
    }
}