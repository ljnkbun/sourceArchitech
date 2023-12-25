using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class BuyerProductCategoryRepository : GenericRepositoryAsync<BuyerProductCategory>, IBuyerProductCategoryRepository
    {
        public BuyerProductCategoryRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<BuyerProductCategory>> GetListAsync(Expression<Func<BuyerProductCategory, bool>> predicate)
        {
            return await _dbContext.Set<BuyerProductCategory>().Where(predicate).ToListAsync();
        }
    }
}