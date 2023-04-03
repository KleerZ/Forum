using AutoMapper;
using Recommendations.Application.Common.Mappings;

namespace Recommendations.Application.CommandsQueries.Product.Queries.GetAll;

public class GetAllProductsDto : IMapWith<Domain.Theme>
{
    public string Name { get; set; }
    public double AverageRating { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Theme, GetAllProductsDto>()
            .ForMember(u => u.Name,
                o => o.MapFrom(u => u.Name));
    }
}