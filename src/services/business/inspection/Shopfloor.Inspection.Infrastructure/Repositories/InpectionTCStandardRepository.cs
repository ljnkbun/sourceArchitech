using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class InpectionTCStandardRepository : GenericRepositoryAsync<InpectionTCStandard>, IInpectionTCStandardRepository
    {
        private readonly DbSet<InpectionTCStandard> _inpectionTCStandards;
        private readonly DbSet<InspectionDefectCapturingTCStandard> _inpectionDefectCapturingTCStandards;
        public InpectionTCStandardRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _inpectionTCStandards = _dbContext.Set<InpectionTCStandard>();
            _inpectionDefectCapturingTCStandards = _dbContext.Set<InspectionDefectCapturingTCStandard>();
        }
        public async Task<InpectionTCStandard> GetInpectionTCStandardWithDetaiḷ(int id)
        {
            return await _inpectionTCStandards.Include(x => x.QCRequestArticle).ThenInclude(x => x.QCRequest)
                                     .Include(x => x.InspectionDefectCapturingTCStandards)
                                     .Include(x => x.Attachments)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateInspectionTCStandardAsync(InpectionTCStandard inspectionTCStandard, IEnumerable<InspectionDefectCapturingTCStandard> inspectionDefectCapturingTCStandards)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _inpectionDefectCapturingTCStandards.UpdateRange(inspectionDefectCapturingTCStandards);
                _inpectionTCStandards.Update(inspectionTCStandard);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
