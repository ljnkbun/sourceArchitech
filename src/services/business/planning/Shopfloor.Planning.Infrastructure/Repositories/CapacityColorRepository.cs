using AutoMapper;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class CapacityColorRepository : GenericRepositoryAsync<CapacityColor>, ICapacityColorRepository
    {
        public CapacityColorRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
