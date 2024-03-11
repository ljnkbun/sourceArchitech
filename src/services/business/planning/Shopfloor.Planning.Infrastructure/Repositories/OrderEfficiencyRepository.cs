using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class OrderEfficiencyRepository : GenericRepositoryAsync<OrderEfficiency>, IOrderEfficiencyRepository
    {
        private readonly DbSet<OrderEfficiency> _orderEfficiencies;
        public OrderEfficiencyRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _orderEfficiencies = _dbContext.Set<OrderEfficiency>();
        }

        public async Task<OrderEfficiency> GetOrderEfficiencyByIdAsync(int? id)
        {
            return await _orderEfficiencies
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<decimal> GetOrderEfficiencyValueAsync(string ocNo)
        {
            var orderEfficiency = await _orderEfficiencies.FirstOrDefaultAsync(x => x.OCNo == ocNo);

            return orderEfficiency?.EfficiencyValue ?? 1M;
        }
    }
}
