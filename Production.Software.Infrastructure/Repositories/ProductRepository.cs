using Production.Software.Core.Entities;
using Production.Software.Core.Repositories;
using Production.Software.Core.Repositories.Base;
using Production.Software.Infrastructure.Data;

namespace Production.Software.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext): base(appDbContext) {}
}