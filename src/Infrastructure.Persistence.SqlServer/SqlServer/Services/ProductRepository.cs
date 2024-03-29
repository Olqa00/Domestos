namespace Domestos.Infrastructure.Persistence.SqlServer.Services;

using Domestos.Domain.Entities;
using Domestos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

internal class ProductRepository : IProductRepository
{
    private readonly SqlServerOptions options;

    private const string INSERT_COMMAND = """
                                          INSERT INTO [dbo].[Product] (
                                          	[Id]
                                          	,[Name]
                                          	)
                                          VALUES (
                                          	@Id
                                          	,@Name
                                          	)
                                          """;

    public ProductRepository(SqlServerOptions options)
    {
	    this.options = options;
    }

    public async Task CreateAsync(ProductEntity productEntity, CancellationToken cancellationToken = default)
    {
	    var parameters = new
	    {
            Id = productEntity.Id.Value,
            Name = productEntity.Name,
	    };

	    await using var connection = new SqlConnection(this.options.ConnectionString);

	    await connection.ExecuteAsync(INSERT_COMMAND, parameters);
    }
}