using MediatR;

namespace Recommendations.Application.CommandsQueries.Product.Commands;

public class CreateProductCommand : IRequest<Domain.Theme>
{
    public string Name { get; set; }

    public CreateProductCommand(string name)
    {
        Name = name;
    }
}