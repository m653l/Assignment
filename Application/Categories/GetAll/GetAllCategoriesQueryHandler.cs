using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using SharedKernel;

namespace Application.Categories.GetAll;

internal sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryResponse>>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public GetAllCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<Result<List<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dbConnectionFactory.GetOpenConnection();

        const string sql = """
            SELECT
                id AS Id,
                full_name AS FullName, 
                short_name AS ShortName
            FROM category
            WHERE status = 0
           """;
        
        return (await connection.QueryAsync<CategoryResponse>(sql)).ToList();
    }
}