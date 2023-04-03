namespace Recommendations.Application.CommandsQueries.Review.Queries;

public class GetAllReviewsVm
{
    public IEnumerable<GetAllReviewsDto> Reviews { get; set; }
}