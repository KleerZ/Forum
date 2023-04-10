namespace Recommendations.Application.CommandsQueries.Comment.Queries.GetAll;

public class GetAllCommentsVm
{
    public IEnumerable<GetCommentDto> Comments { get; set; }

    public GetAllCommentsVm(IEnumerable<GetCommentDto> comments)
    {
        Comments = comments;
    }
}