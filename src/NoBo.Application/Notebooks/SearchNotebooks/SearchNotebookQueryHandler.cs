using Dapper;
using NoBo.Application.Abstractions.Data;
using NoBo.Application.Abstractions.Messaging;
using NoBo.Domain.Abstractions;
using NoBo.Domain.Bookings;

namespace NoBo.Application.Notebooks.SearchNotebooks;

internal sealed class SearchNotebookQueryHandler
    : IQueryHandler<SearchNotebooksQuery, IReadOnlyList<NotebookResponse>>
{
    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchNotebookQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<NotebookResponse>>> Handle(SearchNotebooksQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<NotebookResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                               a.id AS Id,
                               a.name AS Name,
                               a.description AS Description,
                               a.price_amount AS Price,
                               a.price_currency AS Currency,
                               a.article_number AS ArticleNumber,
                           FROM notebooks AS a
                           WHERE NOT EXISTS
                           (
                               SELECT 1
                               FROM bookings AS b
                               WHERE
                                   b.notebook_id = a.id AND
                                   b.duration_start <= @EndDate AND
                                   b.duration_end >= @StartDate AND
                                   b.status = ANY(@ActiveBookingStatuses)
                           )
                           """;

        var notebooks = await connection
            .QueryAsync<NotebookResponse>(
                sql,
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                });

        return notebooks.ToList();
    }
}