using MediatR;
using Microsoft.EntityFrameworkCore;
using Recommendations.Application.Common.Exceptions;
using Recommendations.Application.Interfaces;

namespace Recommendations.Application.CommandsQueries.Review.Queries.Get;

public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, Domain.Discussion>
{
    private readonly IRecommendationsDbContext _context;

    public GetReviewQueryHandler(IRecommendationsDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Discussion> Handle(GetReviewQuery request,
        CancellationToken cancellationToken)
    {
        var review = await _context.Discussions
            .Include(r => r.Theme)
            .Include(r => r.User)
            .Include(r => r.Category)
            .Include(r => r.Likes)
            .Include(r => r.Tags)
            .Include(r => r.Images)
            .FirstOrDefaultAsync(r => r.Id == request.ReviewId, cancellationToken);
        if (review is null)
            throw new NotFoundException(nameof(Review), request.ReviewId);

        return review;
    }
}