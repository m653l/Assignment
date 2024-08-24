using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using SharedKernel;

namespace Application.Products.GetAll;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public GetAllProductsQueryHandler(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<Result<List<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dbConnectionFactory.GetOpenConnection();

        const string sql = """
                           SELECT
                               id AS Id,
                               category_id AS CategoryId,
                               product_name AS ProductName,
                               product_code AS ProductCode,
                               price AS Price
                           FROM product
                           WHERE status = 0
                           """;

        return (await connection.QueryAsync<ProductResponse>(sql)).ToList();
    }
}