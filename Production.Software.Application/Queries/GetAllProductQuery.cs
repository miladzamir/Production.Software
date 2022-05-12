using MediatR;
using Production.Software.Core.Entities;

namespace Production.Software.Application.Queries;

public class GetAllProductQuery: IRequest<List<Product>>
{
}