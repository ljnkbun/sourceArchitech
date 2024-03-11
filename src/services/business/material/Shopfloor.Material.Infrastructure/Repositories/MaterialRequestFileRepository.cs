using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class MaterialRequestFileRepository : GenericRepositoryAsync<MaterialRequestFile>, IMaterialRequestFileRepository
    {
        public MaterialRequestFileRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<MaterialRequestFile>().AnyAsync(x => x.Id == id);
        }
    }
}