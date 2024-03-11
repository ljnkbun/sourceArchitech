using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class KnittingIEDRepository : GenericRepositoryAsync<KnittingIED>, IKnittingIEDRepository
    {
        public KnittingIEDRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<KnittingIED> GetKnittingIEDByIdAsync(int id)
        {
            return await _dbContext.Set<KnittingIED>()
                                    .Include(s => s.KnittingRoutings.OrderBy(r => r.LineNumber))
                                    .Include(s => s.KnittingYarns)
                                    .Include(s => s.KnittingGreiges)
                                    .Include(s => s.KnittingFiles)
                                    .Include(s => s.RequestArticleOutput.RequestDivisionProcess.RequestDivision.RequestDivisionFiles)
                                    .Include(s => s.RequestArticleOutput)
                                        .ThenInclude(s => s.RequestArticleInputs)
                                    .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }
    }
}
