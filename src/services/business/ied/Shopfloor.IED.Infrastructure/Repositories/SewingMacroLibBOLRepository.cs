using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingMacroLibBOLRepository : GenericRepositoryAsync<SewingMacroLibBOL>, ISewingMacroLibBOLRepository
    {
        public SewingMacroLibBOLRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<SewingMacroLibBOL>> GetListAsync(int sewingMacroLibId)
        {
            return await _dbContext.Set<SewingMacroLibBOL>().Where(s => s.SewingMacroLibId == sewingMacroLibId)
                                                            .OrderBy(r => r.LineNumber)
                                                            .ToListAsync();
        }
    }
}
