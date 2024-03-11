using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingRappoMarkRepository : GenericRepositoryAsync<WeavingRappoMark>, IWeavingRappoMarkRepository
    {
        public WeavingRappoMarkRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<WeavingRappoMark>> GetListAsync(int weavingRappoId)
        {
            return await _dbContext.Set<WeavingRappoMark>().Where(s => s.WeavingRappoId == weavingRappoId).ToListAsync();
        }
    }
}
