using MediatR;
using Microsoft.AspNetCore.Http;

namespace Recommendations.Application.CommandsQueries.User.Commands.ChangeAvatar;

public class ChangeAvatarCommand : IRequest
{
    public Guid UserId { get; set; }
    public IFormFile? Image { get; set; }
}