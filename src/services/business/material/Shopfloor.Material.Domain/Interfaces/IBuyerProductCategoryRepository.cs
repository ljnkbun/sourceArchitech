using System.Linq.Expressions;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces;

public interface IBuyerProductCategoryRepository : IGenericRepositoryAsync<BuyerProductCategory>
{
    Task<List<BuyerProductCategory>> GetListAsync(Expression<Func<BuyerProductCategory, bool>> predicate);
}