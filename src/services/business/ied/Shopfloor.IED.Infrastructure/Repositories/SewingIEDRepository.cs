using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingIEDRepository : GenericRepositoryAsync<SewingIED>, ISewingIEDRepository
    {
        public SewingIEDRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingIED> GetSewingIEDByIdAsync(int id)
        {
            return await _dbContext.Set<SewingIED>()
                                    .Include(s => s.SewingRoutings.OrderBy(r => r.LineNumber))
                                    .Include(s => s.SewingFiles)
                                    .Include(s => s.RequestArticleOutput.RequestDivisionProcess.RequestDivision.RequestDivisionFiles)
                                    .Include(s => s.RequestArticleOutput)
                                        .ThenInclude(s => s.RequestArticleInputs)
                                    .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }
    }
}
