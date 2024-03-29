namespace Domestos.Infrastructure.Persistence.SqlServer.Services;

using Dapper;
using Domestos.Infrastructure.Persistence.Interfaces;
using Domestos.Infrastructure.Persistence.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

internal sealed class ProductReadService : IProductReadService
{
    private readonly SqlServerOptions options;

    private const string GET_QUERY = """
                                          SELECT
                                               [Id]
                                              ,[Name]
                                          FROM [Domestos].[dbo].[Product]
                                          """;

    public ProductReadService(SqlServerOptions options)
    {
        this.options = options;
    }

    public async Task<IReadOnlyList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(this.options.ConnectionString);

        var results = (await connection.QueryAsync<Product>(GET_QUERY))
        .ToList()
        .AsReadOnly();

        return results;
    }
}
