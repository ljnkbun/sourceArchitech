using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingDetailStructureRepository : GenericRepositoryAsync<WeavingDetailStructure>, IWeavingDetailStructureRepository
    {
        public WeavingDetailStructureRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<WeavingDetailStructure>> GetAllByWeavingIEDId(int weavingId) => await _dbContext.Set<WeavingDetailStructure>().AsNoTracking()
            .Where(x => x.WeavingIEDId == weavingId).ToListAsync();
    }
}