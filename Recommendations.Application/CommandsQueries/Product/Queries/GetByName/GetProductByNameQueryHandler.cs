using MediatR;
using Microsoft.EntityFrameworkCore;
using Recommendations.Application.Interfaces;

namespace Recommendations.Application.CommandsQueries.Product.Queries.GetByName;

public class GetProductByNameQueryHandler
    : IRequestHandler<GetProductByNameQuery, Domain.Theme?>
{
    private readonly IRecommendationsDbContext _context;

    public GetProductByNameQueryHandler(IRecommendationsDbContext context) =>
        _context = context;

    public async Task<Domain.Theme?> Handle(GetProductByNameQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _context.Themes
            .FirstOrDefaultAsync(p => p.Name == request.ProductName, cancellationToken);
        
        return product;
    }
}