using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class StripSchedulePlanningDetailCaptureRepository : GenericRepositoryAsync<StripSchedulePlanningDetailCapture>, IStripSchedulePlanningDetailCaptureRepository
    {
        public StripSchedulePlanningDetailCaptureRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
