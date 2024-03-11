using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class LineMachineCapacityRepository : GenericRepositoryAsync<LineMachineCapacity>, ILineMachineCapacityRepository
    {
        private readonly DbSet<LineMachineCapacity> _lineMachineCapacity;

        public LineMachineCapacityRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _lineMachineCapacity = dbContext.Set<LineMachineCapacity>();
        }

        public async Task<List<LineMachineCapacity>> GetLineMachineCapacityByDate(DateTime? fDate, DateTime? tDate, List<int> lineIds, List<int> machineIds)
        {
            var query = _lineMachineCapacity
                        .Where(x => x.Date.Value.Date >= fDate && x.Date.Value.Date <= tDate)
                        .AsQueryable();

            if (lineIds.Count > 0)
            {
                query = query.Where(x => lineIds.Contains(x.LineId.Value));
            }
            else
            {
                query = query.Where(x => machineIds.Contains(x.MachineId.Value));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> SaveLineMachineCapacitySync(List<LineMachineCapacity> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _lineMachineCapacity.UpdateRange(entites.Where(x => x.Id > 0));
                _lineMachineCapacity.AddRange(entites.Where(x => x.Id == 0));

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
                return false;
            }
        }
    }
}
