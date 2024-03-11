using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class PlanningGroupRepository : MasterRepositoryAsync<PlanningGroup>, IPlanningGroupRepository
    {
        private readonly DbSet<PlanningGroup> _planningGroups;
        private readonly DbSet<PlanningGroupFactory> _planningGroupFactories;
        public PlanningGroupRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _planningGroups = _dbContext.Set<PlanningGroup>();
            _planningGroupFactories = _dbContext.Set<PlanningGroupFactory>();
        }

        public override async Task<PlanningGroup> GetByIdAsync(int id)
        {
            return await _planningGroups.Include(x => x.PlanningGroupFactories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetPlanningGroupsModelAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _planningGroups.Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .AsSingleQuery()
                    .ToListAsync();
            return response;
        }

        public async Task UpdatePlanningGroupFactoryAsync(PlanningGroup planningGroup, IEnumerable<PlanningGroupFactory> planningGroupFactories)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _planningGroups.Update(planningGroup);
                _planningGroupFactories.UpdateRange(planningGroupFactories.Where(x => x.Id != 0));
                _planningGroupFactories.AddRange(planningGroupFactories.Where(x => x.Id == 0));

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> IsProcessIdExits(int processId, int? id = null)
        {
            return await _planningGroups.AllAsync(x => x.ProcessId != processId || (x.Id == id && x.ProcessId == processId));
        }
    }
}
