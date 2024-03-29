namespace Domestos.Infrastructure.Persistence.PostgreSQL.Services;

using Domestos.Domain.Entities;
using Domestos.Domain.Interfaces;
using Npgsql;
using System.Threading;
using System.Threading.Tasks;
using NpgsqlTypes;

internal sealed class ProductRepository : IProductRepository
{
    private readonly PostgreSQLOptions options;

    private const string INSERT_PRODUCT_COMMAND = """
                                                  INSERT INTO "Products"(
                                                  "Id", "Name")
                                                  VALUES (@Id, @Name)
                                                  """;

    public ProductRepository(PostgreSQLOptions options)
    {
        this.options = options;
    }

    public async Task CreateAsync(ProductEntity productEntity, CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(this.options.ConnectionString);
        await using var command = connection.CreateCommand();
        command.CommandText = INSERT_PRODUCT_COMMAND;
        command.Parameters.Add("@Id", NpgsqlDbType.Uuid).Value = productEntity.Id.Value;
        command.Parameters.Add("@Name", NpgsqlDbType.Text, productEntity.Name.Length).Value = productEntity.Name;
        await connection.OpenAsync(cancellationToken);
        await command.ExecuteScalarAsync(cancellationToken);
    }
}
