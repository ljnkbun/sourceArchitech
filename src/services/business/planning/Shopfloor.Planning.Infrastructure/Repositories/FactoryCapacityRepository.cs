using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class FactoryCapacityRepository : GenericRepositoryAsync<FactoryCapacity>, IFactoryCapacityRepository
    {
        private readonly DbSet<FactoryCapacity> _factoryCapacity;

        public FactoryCapacityRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _factoryCapacity = dbContext.Set<FactoryCapacity>();
        }

        public async Task<List<FactoryCapacity>> GetFactoryCapacityByDate(DateTime? fDate, DateTime? tDate)
        {
            return await _factoryCapacity.Where(x => x.Date >= fDate && x.Date <= tDate).ToListAsync();
        }

        public async Task<List<TModel>> GetFactoryCapacityModelByDate<TModel>(DateTime? fDate, DateTime? tDate, int? processId, int? factoryId) where TModel : class
        {
            var query = _factoryCapacity
                .Where(x => x.Date >= fDate && x.Date <= tDate);

            if (processId != null)
                query = query.Where(x => x.ProcessId == processId);

            if (factoryId != null)
                query = query.Where(x => x.FactoryId == factoryId);

            return await query.ProjectTo<TModel>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task<bool> SaveFactoryCapacitySync(List<FactoryCapacity> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _factoryCapacity.UpdateRange(entites.Where(x => x.Id > 0));
                _factoryCapacity.AddRange(entites.Where(x => x.Id == 0));

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
