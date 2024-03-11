using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class StripSchedulePlanningDetailRepository : GenericRepositoryAsync<StripSchedulePlanningDetail>, IStripSchedulePlanningDetailRepository
    {
        public StripSchedulePlanningDetailRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<StripSchedulePlanningDetail> GetByFPPOIdAsync(int id, DateTime date)
        {
            var fppo = await _dbContext.Set<FPPO>().FirstOrDefaultAsync(f => f.Id == id);
            if (fppo == null)
                return null;
            return await _dbContext.Set<StripSchedulePlanningDetail>().FirstOrDefaultAsync(d => d.StripSchedule.Id == fppo.StripScheduleId && d.Date.Equals(date));
        }
    }
}
