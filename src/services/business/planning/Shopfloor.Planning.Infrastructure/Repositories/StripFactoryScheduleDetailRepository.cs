using AutoMapper;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class StripFactoryScheduleDetailRepository : GenericRepositoryAsync<StripFactoryScheduleDetail>, IStripFactoryScheduleDetailRepository
    {
        public StripFactoryScheduleDetailRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
