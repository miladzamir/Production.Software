using MediatR;
using Production.Software.Application.Commands;
using Production.Software.Application.Mappers;
using Production.Software.Application.Responses;
using Production.Software.Core.Entities;
using Production.Software.Core.Repositories;

namespace Production.Software.Application.Handlers.CommandHandlers;

public class CreateProductHandler: IRequestHandler<CreateProductCommand, ProductResponse> 
{
    private readonly IProductRepository _productRepository;
    public CreateProductHandler(IProductRepository productRepository) {
        _productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
        var productEntity = ProductMapper.Mapper.Map<Product>(request);
        if (productEntity is null) {
            throw new ApplicationException("Issue with mapper");
        }
        var newProduct = await _productRepository.AddAsync(productEntity);
        var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
        return productResponse;
    }
}