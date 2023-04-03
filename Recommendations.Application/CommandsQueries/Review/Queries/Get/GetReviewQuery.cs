using MediatR;

namespace Recommendations.Application.CommandsQueries.Review.Queries.Get;

public class GetReviewQuery : IRequest<Domain.Discussion>
{
    public Guid ReviewId { get; set; }

    public GetReviewQuery(Guid reviewId)
    {
        ReviewId = reviewId;
    }
}