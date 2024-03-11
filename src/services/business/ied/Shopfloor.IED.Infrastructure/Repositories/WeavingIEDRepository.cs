using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingIEDRepository : GenericRepositoryAsync<WeavingIED>, IWeavingIEDRepository
    {
        public WeavingIEDRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<WeavingIED>().AnyAsync(x => x.Id == id);
        }

        public async Task<WeavingIED> GetWeavingIEDByIdAsync(int id)
        {
            return await _dbContext.Set<WeavingIED>()
                                    .Include(s => s.WeavingRoutings.OrderBy(r => r.LineNumber))
                                    .ThenInclude(x => x.WeavingOperations.OrderBy(x => x.LineNumber))
                                    .ThenInclude(x => x.WeavingOperationInputArticles)
                                    .Include(s => s.WeavingYarns)
                                    .Include(s => s.WeavingRusticFabricSpec)
                                    .Include(s => s.WeavingDetailStructures)
                                    .Include(s => s.WeavingRappo)
                                        .ThenInclude(r => r.WeavingRappoMatrics)
                                        .ThenInclude(x => x.HorizontalYarn)
                                        .Include(s => s.WeavingRappo)
                                        .ThenInclude(r => r.WeavingRappoMatrics)
                                        .ThenInclude(x => x.VerticleYarn)
                                    .Include(s => s.WeavingRappo)
                                        .ThenInclude(r => r.WeavingRappoMarks)
                                    .Include(s => s.WeavingFiles)
                                    .Include(x => x.WeavingReportSetting)
                                    .ThenInclude(x => x.WeavingReportSettingDetails)
                                    .Include(s => s.RequestArticleOutput.RequestDivisionProcess.RequestDivision.RequestDivisionFiles)
                                    .Include(s => s.RequestArticleOutput)
                                        .ThenInclude(s => s.RequestArticleInputs)
                                    .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }
    }
}