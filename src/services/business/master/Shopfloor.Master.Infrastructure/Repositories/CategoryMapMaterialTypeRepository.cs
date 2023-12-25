using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class CategoryMapMaterialTypeRepository : GenericRepositoryAsync<CategoryMapMaterialType>, ICategoryMapMaterialTypeRepository
    {
        public CategoryMapMaterialTypeRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsDuplicateAsync(int? categoryId, int? materialTypeId, int? id = null)
        {
            return await _dbContext.Set<CategoryMapMaterialType>().AllAsync(x =>
            (x.CategoryId != categoryId || x.MaterialTypeId != materialTypeId) || (x.Id == id && (x.CategoryId == categoryId || x.MaterialTypeId == materialTypeId)));
        }
    }
}
