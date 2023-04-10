using AutoMapper;
using Recommendations.Application.CommandsQueries.User.Commands.ChangeAvatar;
using Recommendations.Application.Common.Mappings;

namespace Recommendations.Web.Models.User;

public class ChangeAvatarDto : IMapWith<ChangeAvatarCommand>
{
    public IFormFile? Image { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChangeAvatarDto, ChangeAvatarCommand>();
    }
}