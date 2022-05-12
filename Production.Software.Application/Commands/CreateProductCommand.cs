using MediatR;
using Production.Software.Application.Responses;

namespace Production.Software.Application.Commands;

public class CreateProductCommand : IRequest<ProductResponse> 
{
    public string Name { get; set; }
}