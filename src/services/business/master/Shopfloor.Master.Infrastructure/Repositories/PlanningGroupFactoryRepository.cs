using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class PlanningGroupFactoryRepository : GenericRepositoryAsync<PlanningGroupFactory>, IPlanningGroupFactoryRepository
    {
        private readonly DbSet<PlanningGroupFactory> _planningGroupFactory;

        public PlanningGroupFactoryRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _planningGroupFactory = _dbContext.Set<PlanningGroupFactory>();
        }

        public override async Task<PlanningGroupFactory> GetByIdAsync(int id)
        {
            return await _planningGroupFactory
                .Include(x => x.PlanningGroup)
                    .ThenInclude(x => x.Process)
                .Include(x => x.Factory)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<PlanningGroupFactory>> GetByIds(List<int> ids)
        {
            return await _planningGroupFactory
                .Include(x => x.PlanningGroup)
                    .ThenInclude(x => x.Process)
                .Include(x => x.Factory)
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
