using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingOperationLibBOLRepository : GenericRepositoryAsync<SewingOperationLibBOL>, ISewingOperationLibBOLRepository
    {
        public SewingOperationLibBOLRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<SewingOperationLibBOL>> GetListAsync(int sewingOperationLibId)
        {
            return await _dbContext.Set<SewingOperationLibBOL>().Where(s => s.SewingOperationLibId == sewingOperationLibId)
                                                                .OrderBy(r => r.LineNumber)
                                                                .ToListAsync();
        }
    }
}
