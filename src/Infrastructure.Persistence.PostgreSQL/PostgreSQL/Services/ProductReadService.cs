namespace Domestos.Persistence.PostgreSQL.Services;

using Domestos.Persistence.Interfaces;
using Domestos.Persistence.Models;
using Npgsql;

internal sealed class ProductReadService : IProductReadService
{
    private readonly PostgreSQLOptions options;

    private const string GET_QUERY = """
                                     SELECT "Id", "Name"
                                     FROM "Products";
                                     """;

    public ProductReadService(PostgreSQLOptions options)
    {
        this.options = options;
    }

    public async Task<IReadOnlyList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(this.options.ConnectionString);
        await using var command = connection.CreateCommand();
        command.CommandText = GET_QUERY;
        await connection.OpenAsync(cancellationToken);
        var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        
        var results = new List<Product>();

        while (await dataReader.ReadAsync(cancellationToken))
        {
            var id = dataReader.GetGuid(dataReader.GetOrdinal("Id"));
            var name = dataReader.GetString(dataReader.GetOrdinal("Name"));

            var product = new Product
            {
                Id = id,
                Name = name,
            };

            results.Add(product);
        }

        return results;
    }
}
