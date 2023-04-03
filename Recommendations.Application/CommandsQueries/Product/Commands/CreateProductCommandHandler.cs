using MediatR;
using Recommendations.Application.Interfaces;

namespace Recommendations.Application.CommandsQueries.Product.Commands;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Domain.Theme>
{
    private readonly IRecommendationsDbContext _context;

    public CreateProductCommandHandler(IRecommendationsDbContext context) =>
        _context = context;

    public async Task<Domain.Theme> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Domain.Theme
        {
            Name = request.Name
        };
        await _context.Themes.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return product;
    }
}