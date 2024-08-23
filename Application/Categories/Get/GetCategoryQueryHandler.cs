using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Categories;
using SharedKernel;

namespace Application.Categories.Get;

internal sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryResponse>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public GetCategoryQueryHandler(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dbConnectionFactory.GetOpenConnection();

        const string sql = """
            SELECT
                id AS Id,
                full_name AS FullName,
                short_name AS ShortName
            FROM category
            WHERE id = @categoryId AND status = 0
            """;

        var category = await connection.QueryFirstOrDefaultAsync<CategoryResponse>(
            sql,
            new
            {
                request.categoryId,
            });

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound(request.categoryId));
        }

        return category;
    }
}
