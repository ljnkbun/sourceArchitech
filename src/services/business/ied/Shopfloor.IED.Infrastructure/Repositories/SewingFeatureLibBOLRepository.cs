using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingFeatureLibBOLRepository : GenericRepositoryAsync<SewingFeatureLibBOL>, ISewingFeatureLibBOLRepository
    {
        public SewingFeatureLibBOLRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<SewingFeatureLibBOL>> GetListAsync(int sewingFeatureLibId)
        {
            return await _dbContext.Set<SewingFeatureLibBOL>().Where(s => s.SewingFeatureLibId == sewingFeatureLibId).ToListAsync();
        }
    }
}
