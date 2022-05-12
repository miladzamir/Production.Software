using MediatR;
using Production.Software.Application.Queries;
using Production.Software.Core.Entities;
using Production.Software.Core.Repositories;

namespace Production.Software.Application.Handlers.QueryHandlers;

public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return (List<Product>)await _productRepository.GetAllAsync();
    }
}