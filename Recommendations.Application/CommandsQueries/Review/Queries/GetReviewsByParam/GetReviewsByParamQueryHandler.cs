using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recommendations.Application.CommandsQueries.Review.Queries.GetMostRatedList;
using Recommendations.Application.CommandsQueries.Review.Queries.GetRecentList;
using Recommendations.Application.Interfaces;

namespace Recommendations.Application.CommandsQueries.Review.Queries.GetReviewsByParam;

public class GetReviewsByParamQueryHandler
    : IRequestHandler<GetReviewsByParamQuery, GetAllReviewsVm>
{
    private readonly IRecommendationsDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetReviewsByParamQueryHandler(IRecommendationsDbContext context, 
        IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<GetAllReviewsVm> Handle(GetReviewsByParamQuery request,
        CancellationToken cancellationToken)
    {
        var reviews = await _context.Discussions
            .Include(c => c.Category)
            .Include(c => c.Tags)
            .Include(c => c.Theme)
            .Include(c => c.Images)
            .Include(c => c.User)
            .ProjectTo<GetAllReviewsDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (request.Tag is not null)
        {
            reviews = reviews.Where(r => 
                r.Tags.Contains(request.Tag)).ToList();
        }

        return new GetAllReviewsVm { Reviews = reviews };
    }

    private async Task<List<GetAllReviewsDto>> GetRecentReviews(int? count,
        CancellationToken cancellationToken)
    {
        var getRecentReviewsQuery = new GetRecentReviewsQuery(count);
        var reviewsVm = await _mediator.Send(getRecentReviewsQuery, cancellationToken);
        return reviewsVm.Reviews.ToList();
    }

    private async Task<List<GetAllReviewsDto>> GetMostRatedReviews(int? count,
        CancellationToken cancellationToken)
    {
        var getMostRatedReviewsQuery = new GetMostRatedListQuery(count);
        var reviewsVm = await _mediator.Send(getMostRatedReviewsQuery, cancellationToken);
        return reviewsVm.Reviews.ToList();
    }
}