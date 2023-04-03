using MediatR;

namespace Recommendations.Application.CommandsQueries.Review.Queries.GetMostRatedList;

public class GetMostRatedListQuery : IRequest<GetAllReviewsVm>
{
    public int? Count { get; set; }

    public GetMostRatedListQuery(int? count)
    {
        Count = count;
    }
}