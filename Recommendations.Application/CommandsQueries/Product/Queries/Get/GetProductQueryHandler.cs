using MediatR;
using Microsoft.EntityFrameworkCore;
using Recommendations.Application.Common.Exceptions;
using Recommendations.Application.Interfaces;

namespace Recommendations.Application.CommandsQueries.Product.Queries.Get;

public class GetProductQueryHandler
    : IRequestHandler<GetProductQuery, Domain.Theme>
{
    private readonly IRecommendationsDbContext _context;

    public GetProductQueryHandler(IRecommendationsDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Theme> Handle(GetProductQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _context.Themes
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
        if (product is null)
            throw new NotFoundException(nameof(Product), request.ProductId);
        
        return product;
    }
}