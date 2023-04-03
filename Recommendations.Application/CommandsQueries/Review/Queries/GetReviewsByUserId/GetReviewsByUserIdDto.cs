using AutoMapper;
using Recommendations.Application.Common.Mappings;

namespace Recommendations.Application.CommandsQueries.Review.Queries.GetReviewsByUserId;

public class GetReviewsByUserIdDto : IMapWith<Domain.Discussion>
{
    public Guid ReviewId { get; set; }
    public string ReviewTitle { get; set; }
    public DateTime CreationDate { get; set; }
    public string Category { get; set; }
    public string Product { get; set; }
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
    public double AverageRate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Discussion, GetReviewsByUserIdDto>()
            .ForMember(u => u.ReviewId,
                o => o.MapFrom(u => u.Id))
            .ForMember(u => u.ReviewTitle,
                o => o.MapFrom(u => u.Title))
            .ForMember(u => u.CreationDate,
                o => o.MapFrom(u => u.CreationDate))
            .ForMember(u => u.Category,
                o => o.MapFrom(u => u.Category.Name))
            .ForMember(u => u.Product,
                o => o.MapFrom(u => u.Theme.Name))
            .ForMember(u => u.LikesCount,
                o => o.MapFrom(u => u.Likes
                    .Count(l => l.Status)))
            .ForMember(u => u.CommentsCount,
                o => o.MapFrom(u => u.Comments.Count));
    }
}