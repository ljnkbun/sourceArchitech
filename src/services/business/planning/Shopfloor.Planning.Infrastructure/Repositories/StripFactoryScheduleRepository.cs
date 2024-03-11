using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class StripFactoryScheduleRepository : GenericRepositoryAsync<StripFactorySchedule>, IStripFactoryScheduleRepository
    {
        private readonly DbSet<StripFactory> _stripFactories;
        private readonly DbSet<StripSchedule> _stripSchedules;
        private readonly DbSet<StripFactorySchedule> _stripFactorySchedules;

        public StripFactoryScheduleRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _stripFactories = dbContext.Set<StripFactory>();
            _stripSchedules = dbContext.Set<StripSchedule>();
            _stripFactorySchedules = dbContext.Set<StripFactorySchedule>();
        }

        public async Task<StripFactorySchedule> GetStripFactoryScheduleByScheduleId(int stripScheduleId)
        {
            return await _stripFactorySchedules.Include(x => x.StripFactoryScheduleDetails)
                .FirstOrDefaultAsync(x => x.StripScheduleId == stripScheduleId);
        }

        public async Task<bool> SplitBatchAsync(StripFactorySchedule stripFactorySchedule, StripFactory stripFactory)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //Update RemainingQuantity StripFactoryDetail
                stripFactorySchedule.Quantity = stripFactorySchedule.StripFactoryScheduleDetails.Sum(s => s.Quantity);
                foreach (var item in stripFactorySchedule.StripFactoryScheduleDetails)
                {
                    var sfd = stripFactory.StripFactoryDetails.FirstOrDefault(s => s.Size == item.Size
                                                                                && s.Color == item.Color
                                                                                && s.UOM == item.UOM);
                    sfd.RemainingQuantity = sfd.RemainingQuantity - item.Quantity;
                }
                stripFactory.RemainningQuantity = stripFactory.StripFactoryDetails.Sum(s => s.RemainingQuantity);
                stripFactory.IsSplitBatch = true;

                _stripFactorySchedules.Add(stripFactorySchedule);
                _stripFactories.Update(stripFactory);

                // Save changes
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

        public async Task DeleteStripFactorySchedule(StripFactorySchedule entity)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var stripFactory = await _stripFactories
                    .Include(x => x.StripFactoryDetails)
                    .FirstOrDefaultAsync(x => x.Id == entity.StripFactoryId);

                var stripFactoryCount = await _stripFactorySchedules
                    .Select(x => x.StripFactoryId).CountAsync();

                if (stripFactoryCount == 1) stripFactory.IsSplitBatch = false;

                //Revert SF
                foreach (var item in entity.StripFactoryScheduleDetails)
                {
                    var stripFactoryDetail = stripFactory.StripFactoryDetails.FirstOrDefault(s => s.Size == item.Size
                                                                            && s.Color == item.Color
                                                                            && s.UOM == item.UOM);
                    stripFactoryDetail.RemainingQuantity += item.Quantity;
                }
                stripFactory.RemainningQuantity = stripFactory.StripFactoryDetails.Sum(x => x.RemainingQuantity);

                //Update SF
                _stripFactories.Update(stripFactory);

                //Remove SFS
                _stripFactorySchedules.Remove(entity);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }
        }

        public async Task<IReadOnlyList<TModel>> GetStripFactorySheduleAsync<TModel>(string articleCode) where TModel : class
        {
            return await _dbContext.Set<StripFactorySchedule>()
                                           .Where(x => x.StripFactory.Por.ArticleCode == articleCode)
                                           .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                                           .ToListAsync();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetStripFactoryScheduleModelPagedReponseAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<StripFactorySchedule>().Filter(parameter);
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

        public async Task<StripFactorySchedule> GetStripFactoryScheduleInculeById(int id)
        {
            return await _stripFactorySchedules
                .Include(x => x.StripFactoryScheduleDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
