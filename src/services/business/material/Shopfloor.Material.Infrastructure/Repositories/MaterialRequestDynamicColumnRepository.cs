using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class MaterialRequestDynamicColumnRepository : GenericRepositoryAsync<MaterialRequestDynamicColumn>, IMaterialRequestDynamicColumnRepository
    {
        public MaterialRequestDynamicColumnRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsUniqueAsync(int dynamicColumnId, int? id = null)
        {
            return await _dbContext.Set<MaterialRequestDynamicColumn>().AllAsync(x => x.DynamicColumnId != dynamicColumnId || (x.Id == id && x.DynamicColumnId == dynamicColumnId));
        }

        public async Task<bool> IsExistAsync(int dynamicColumnId)
        {
            return await _dbContext.Set<DynamicColumn>().AnyAsync(x => x.Id == dynamicColumnId);
        }
    }
}