using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class MaterialTypeMapProductGroupRepository : GenericRepositoryAsync<MaterialTypeMapProductGroup>, IMaterialTypeMapProductGroupRepository
    {
        public MaterialTypeMapProductGroupRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsDuplicateAsync(int? materialTypeId, int? productGroupId, int? id = null)
        {
            return await _dbContext.Set<MaterialTypeMapProductGroup>().AllAsync(x =>
                (x.MaterialTypeId != materialTypeId || x.ProductGroupId != productGroupId) || (x.Id == id && (x.MaterialTypeId == materialTypeId || x.ProductGroupId == productGroupId)));
        }
    }
}
