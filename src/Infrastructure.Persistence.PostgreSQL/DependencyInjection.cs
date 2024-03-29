namespace Domestos.Infrastructure.Persistence;

using Domestos.Domain.Interfaces;
using Domestos.Infrastructure.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domestos.Infrastructure.Persistence.PostgreSQL.Services;
using Npgsql;

public static class DependencyInjection
{
    public static void AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new PostgreSQLOptions();
        var connectionString = configuration.GetConnectionString("DomestosConnection");
        CheckConnection(connectionString);
        

        options.ConnectionString = connectionString;
        services.AddSingleton(options);

        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductReadService, ProductReadService>();
    }

    private static void CheckConnection(string connectionString)
    {
        var query = "SELECT version();";

        using var connection = new NpgsqlConnection(connectionString);
        using var command = connection.CreateCommand();
        command.CommandText = query;
        connection.Open();
        command.ExecuteScalar();
    }
}