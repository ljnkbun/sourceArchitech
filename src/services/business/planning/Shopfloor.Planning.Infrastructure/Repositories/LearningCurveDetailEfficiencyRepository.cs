using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class LearningCurveDetailEfficiencyRepository : MasterRepositoryAsync<LearningCurveDetailEfficiency>, ILearningCurveDetailEfficiencyRepository
    {
        public LearningCurveDetailEfficiencyRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
