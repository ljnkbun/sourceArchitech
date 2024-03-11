using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Serilog;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using Log = Serilog.Log;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class StripScheduleRepository : GenericRepositoryAsync<StripSchedule>, IStripScheduleRepository
    {

        private readonly DbSet<StripSchedule> _stripSchedules;
        private readonly DbSet<StripFactorySchedule> _stripFactorySchedules;
        private readonly DbSet<StripFactory> _stripFactories;
        private readonly DbSet<StripFactoryDetail> _stripFactoryDetails;
        public StripScheduleRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _stripSchedules = dbContext.Set<StripSchedule>();
            _stripFactories = dbContext.Set<StripFactory>();
            _stripFactoryDetails = dbContext.Set<StripFactoryDetail>();
            _stripFactorySchedules = dbContext.Set<StripFactorySchedule>();
        }

        public async Task DeleteSplitBatchOrNotAsync(StripSchedule stripSchedule, StripFactorySchedule stripFactorySchedule)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var stripFactory = await _stripFactories
                        .Include(x => x.StripFactoryDetails)
                        .FirstOrDefaultAsync(x => x.Id == stripFactorySchedule.StripFactoryId);

                if (!string.IsNullOrEmpty(stripFactorySchedule.BatchNo))
                {
                    stripFactorySchedule.StripScheduleId = null;
                    _stripFactorySchedules.Update(stripFactorySchedule);
                }
                else
                {
                    //Revert SF
                    foreach (var item in stripSchedule.StripScheduleDetails)
                    {
                        var stripFactoryDetail = stripFactory.StripFactoryDetails.FirstOrDefault(s => s.Size == item.Size
                                                                                && s.Color == item.Color
                                                                                && s.UOM == item.UOM);
                        stripFactoryDetail.RemainingQuantity += item.Quantity;
                    }
                    stripFactory.RemainningQuantity = stripFactory.StripFactoryDetails.Sum(x => x.RemainingQuantity);

                    //Remove SFS
                    _stripFactorySchedules.Remove(stripFactorySchedule);
                }

                //Update SF
                _stripFactories.Update(stripFactory);

                // Remove SS
                _stripSchedules.Remove(stripSchedule);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }
        }

        public async Task<StripSchedule> GetByIdAsNo(int id)
        {
            return await _stripSchedules.Include(x => x.StripScheduleDetails).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<StripSchedule> GetByIdAsync(int id)
        {
            return await _stripSchedules
                .Include(x => x.StripScheduleDetails)
                .Include(x => x.StripSchedulePlanningDetails)
                .Include(x => x.StripFactorySchedules)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<StripSchedule>> GetStripScheduleByListId(List<int> ids)
        {
            return await _stripSchedules.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<ICollection<StripSchedule>> GetStripScheduleByMachineIdAsync(int id)
        {
            var data = await _stripSchedules
               .Include(x => x.StripScheduleDetails)
               .Include(x => x.StripSchedulePlanningDetails)
               .Include(x => x.StripFactorySchedules)
            .Include(x => x.StripFactorySchedules).Where(x => x.MachineId == id && x.ToDate.Date >= DateTime.Now.Date).OrderBy(x => x.ToDate).ToListAsync();
            return data;
        }

        public async Task<ICollection<StripSchedule>> GetStripScheduleByLineIdAsync(int id)
        {
            var data = await _stripSchedules
               .Include(x => x.StripScheduleDetails)
               .Include(x => x.StripSchedulePlanningDetails)
               .Include(x => x.StripFactorySchedules)
            .Include(x => x.StripFactorySchedules).Where(x => x.LineId == id && x.ToDate.Date >= DateTime.Now.Date).OrderBy(x => x.ToDate).ToListAsync();
            return data;
        }

        public async Task<List<StripSchedule>> GetStripScheduleByPars(List<int> machineIds, List<int> lineIds, DateTime fDate, DateTime tDate)
        {
            return await _stripSchedules
                .Include(x => x.StripScheduleDetails)
                .Include(x => x.StripSchedulePlanningDetails)
                .Where(x => (lineIds.Contains(x.LineId.Value) || (lineIds.Count == 0 && machineIds.Contains(x.MachineId.Value)))
                    && x.FromDate >= fDate && x.ToDate <= tDate).ToListAsync();
        }

        public Task<ICollection<StripSchedule>> GetStripScheduleForCalculate(int? lineId, int? machineId, DateTime fDate, DateTime tDate)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetStripScheduleModelAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _stripSchedules.Filter(parameter);
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

        public async Task<Response<IReadOnlyList<TModel>>> GetStripSheduleAsync<TModel>(string articleCode)
            where TModel : class
        {
            var response = await _dbContext.Set<StripSchedule>()
                                           .Include(x => x.StripFactorySchedules)
                                           .Where(x => x.StripFactorySchedules.Any(y => y.StripFactory.Por.ArticleCode == articleCode))
                                           .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                                           .ToListAsync();
            return new Response<IReadOnlyList<TModel>>(response);
        }

        public async Task<bool> SaveRangeStripSchedule(List<StripSchedule> stripSchedules)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var existsStripSchedules = stripSchedules.Where(x => x.Id > 0).ToList();
                var newStripSchedules = stripSchedules.Where(x => x.Id == 0).ToList();

                var stripFactoryIds = newStripSchedules.SelectMany(x => x.StripFactorySchedules.Where(c => string.IsNullOrEmpty(c.BatchNo)).Select(x => x.StripFactoryId));
                var stripFactories = await _stripFactories.Where(x => stripFactoryIds.Contains(x.Id)).ToListAsync();

                foreach (var item in stripFactories)
                {
                    item.RemainningQuantity = 0;
                    item.IsPlanning = true;
                }

                var stripFactoryDetails = await _stripFactoryDetails.Where(x => stripFactoryIds.Contains(x.StripFactoryId)).ToListAsync();

                foreach (var item in stripFactoryDetails)
                    item.RemainingQuantity = 0;

                _stripSchedules.UpdateRange(existsStripSchedules);
                _stripSchedules.AddRange(newStripSchedules);

                _stripFactories.UpdateRange(stripFactories);
                _stripFactoryDetails.UpdateRange(stripFactoryDetails);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }

            return false;
        }
    }
}