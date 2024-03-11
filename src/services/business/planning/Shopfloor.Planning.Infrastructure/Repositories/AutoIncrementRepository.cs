using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class AutoIncrementRepository : GenericRepositoryAsync<AutoIncrement>, IAutoIncrementRepository
    {
        public AutoIncrementRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}