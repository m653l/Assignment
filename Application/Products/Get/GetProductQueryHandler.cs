using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Products;
using SharedKernel;

namespace Application.Products.Get;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductResponse>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public GetProductQueryHandler(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dbConnectionFactory.GetOpenConnection();

        const string sql = """
            SELECT
                id AS Id,
                product_name AS ProductName,
                product_code AS ProductCode,
                price AS Price,
                category_id AS CategoryId
            FROM product
            WHERE id = @productId AND status = 0
            """;

        var product = await connection.QueryFirstOrDefaultAsync<ProductResponse>(
            sql,
            new
            {
                request.productId
            });

        if (product is null)
        {
            return Result.Failure<ProductResponse>(ProductErrors.NotFound(request.productId));
        }

        return product;
    }
}
