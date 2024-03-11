using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ProductGroupUOMRepository : GenericRepositoryAsync<ProductGroupUOM>, IProductGroupUOMRepository
    {
        public ProductGroupUOMRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsDuplicateAsync(int? productGroupId, int? uOMId, int? id = null)
        {
            return await _dbContext.Set<ProductGroupUOM>().AllAsync(x =>
            (x.ProductGroupId != productGroupId || x.UOMId != uOMId) || (x.Id == id && (x.ProductGroupId == productGroupId || x.UOMId == uOMId)));
        }
    }
}