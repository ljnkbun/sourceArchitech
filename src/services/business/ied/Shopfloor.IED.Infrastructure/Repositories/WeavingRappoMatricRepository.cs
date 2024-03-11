using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingRappoMatricRepository : GenericRepositoryAsync<WeavingRappoMatric>, IWeavingRappoMatricRepository
    {
        public WeavingRappoMatricRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<WeavingRappoMatric>> GetListAsync(int weavingRappoId)
        {
            return await _dbContext.Set<WeavingRappoMatric>().Where(s => s.WeavingRappoId == weavingRappoId).ToListAsync();
        }
    }
}
