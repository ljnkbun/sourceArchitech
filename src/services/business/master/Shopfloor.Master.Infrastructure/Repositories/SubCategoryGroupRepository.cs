using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class SubCategoryGroupRepository : MasterRepositoryAsync<SubCategoryGroup>, ISubCategoryGroupRepository
    {
        public SubCategoryGroupRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<SubCategoryGroup>().AnyAsync(x => x.Id == id);
        }
    }
}
