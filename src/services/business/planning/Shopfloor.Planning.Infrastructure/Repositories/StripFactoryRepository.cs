using AutoMapper;
using AutoMapper.QueryableExtensions;
using MassTransit.Internals;
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
    public class StripFactoryRepository : GenericRepositoryAsync<StripFactory>, IStripFactoryRepository
    {
        private readonly DbSet<StripFactory> _stripFactories;
        private readonly DbSet<POR> _por;
        private readonly DbSet<PORDetail> _porDetail;
        private readonly DbSet<StripFactoryDetail> _stripFactoryDetail;

        public StripFactoryRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _stripFactories = dbContext.Set<StripFactory>();
            _por = dbContext.Set<POR>();
            _porDetail = dbContext.Set<PORDetail>();
            _stripFactoryDetail = dbContext.Set<StripFactoryDetail>();
        }

        public async override Task<StripFactory> GetByIdAsync(int id)
        {
            return await _stripFactories.Include(x => x.StripFactoryDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<TModel>> GetModelByArticleCodeAsync<TModel>(string articleCode)
            where TModel : class
        {
            return await _stripFactories.Where(x => x.Por.ArticleCode == articleCode)
                    .OrderByDescending(x => x.StartDate)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<int>> GetPORIdsFromStripFactory(DateTime? fDate, DateTime? tDate, List<int> pfIds)
        {
            var stripFactorys = _stripFactories
                .Where(x => x.StartDate >= fDate && x.EndDate <= tDate && x.IsAllocated == true).AsQueryable();
            if (pfIds.Count > 0)
            {
                stripFactorys = stripFactorys.Where(x => pfIds.Contains(x.PlanningGroupFactoryId));
            }

            return await stripFactorys.Select(x => x.PORId).ToListAsync();
        }

        public async Task<IReadOnlyList<TModel>> GetStripFactoryPorsAsync<TModel>(int planningGroupFactoryId, DateTime startDate, DateTime endDate)
            where TModel : class
        {
            return await _stripFactories
                .Where(x => x.StartDate >= startDate && x.EndDate <= endDate && x.PlanningGroupFactoryId == planningGroupFactoryId)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<StripFactory> GetStripFactoryByIsAllocatedIsFalse(int id)
        {
            return await _stripFactories.FirstOrDefaultAsync(x => x.Id == id && x.IsAllocated == false);
        }

        public async Task<int?> InsertStripFactory(StripFactory entity)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _stripFactories.AddAsync(entity);

                //Update RemainingQuantity is 0
                var por = await _por.FirstOrDefaultAsync(x => x.Id == entity.PORId);
                por.RemainingQuantity = 0; _por.Update(por);

                //Update RemainingQuantity PorDetails is 0
                var porDetails = await _porDetail.Where(x => x.PORId == por.Id).ToListAsync();
                foreach (var item in porDetails)
                {
                    item.RemainingQuantity = 0;
                }
                _porDetail.UpdateRange(porDetails);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }

            return null;
        }

        public async Task<bool> SaveMultipleStripFactory(List<StripFactory> stripFactories)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var existsStripFactories = stripFactories.Where(x => x.Id > 0).ToList();
                var newStripFactories = stripFactories.Where(x => x.Id == 0).ToList();

                // GET PORs
                var porIds = existsStripFactories.Select(x => x.PORId).Concat(newStripFactories.Select(x => x.PORId)).Distinct();
                var pors = await _por.Where(por => porIds.Contains(por.Id)).ToListAsync();

                foreach (var item in stripFactories)
                {
                    var por = pors.FirstOrDefault(x => x.Id == item.PORId);
                    item.RemainningQuantity = por.Quantity;
                    item.Quantity = item.StripFactoryDetails.Sum(x => x.Quantity);
                }

                _stripFactories.UpdateRange(existsStripFactories);
                _stripFactories.AddRange(newStripFactories);

                // Update POR
                foreach (var por in pors)
                    por.RemainingQuantity = 0;
                _por.UpdateRange(pors);

                // Update POR-Detail
                var porDetails = await _porDetail.Where(porDetail => porIds.Contains(porDetail.PORId)).ToListAsync();

                foreach (var porDetail in porDetails)
                    porDetail.RemainingQuantity = 0;
                _porDetail.UpdateRange(porDetails);

                // Save changes for both POR and PORDetail
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

        public async Task<bool> IsExitPlanningGroupFactoryId(int planningGroupFactoryId)
        {
            return await _stripFactories.AnyAsync(x => x.PlanningGroupFactoryId == planningGroupFactoryId);
        }

        public async Task<bool> RejectStripFactoryAsync(List<StripFactory> entities)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var porIds = entities.Select(x => x.PORId).Distinct().ToList();
                var pors = await _por.Include(x => x.PORDetails).Where(x => porIds.Contains(x.Id)).ToListAsync();

                foreach (var entity in entities)
                {
                    var por = pors.FirstOrDefault(x => x.Id == entity.PORId);
                    por.RemainingQuantity += entity.Quantity;
                    foreach (var detail in por.PORDetails)
                    {
                        detail.RemainingQuantity += entity.StripFactoryDetails.Where(x => x.PorDetailId == detail.Id).Sum(x => x.RemainingQuantity);
                    }
                }

                _por.UpdateRange(pors);
                _porDetail.UpdateRange(pors.SelectMany(x => x.PORDetails));

                _stripFactories.RemoveRange(entities);

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

        public async Task<List<StripFactory>> GetByIdsAsync(List<int> ids)
        {
            return await _stripFactories.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<StripFactory>> GetWithDetailByIdsAsync(List<int> ids)
        {
            return await _stripFactories.Include(x => x.StripFactoryDetails).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task DeleteStripFactory(StripFactory stripFactory)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var porUpdate = await _por.Include(x => x.PORDetails).FirstOrDefaultAsync(x => x.Id == stripFactory.PORId);
                porUpdate.RemainingQuantity = stripFactory.Quantity;

                foreach (var porDetail in porUpdate.PORDetails)
                {
                    porDetail.RemainingQuantity = stripFactory.StripFactoryDetails.FirstOrDefault(x => x.PorDetailId == porDetail.Id).RemainingQuantity;
                }

                _stripFactoryDetail.RemoveRange(stripFactory.StripFactoryDetails);
                _stripFactories.Remove(stripFactory);
                _por.UpdateRange(porUpdate);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }
        }

        public virtual async Task<PagedResponse<IReadOnlyList<TModel>>> GetStripFactoryModelPagedReponseAsync<TParam, TModel>(TParam parameter, 
            int? processId,
            string articleName,
            string articleCode,
            string buyer,
            string category,
            string subCategory,
            string productGroup,
            string jobOrderNo,
            string batchNo)
            where TModel : class
            where TParam : RequestParameter
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<StripFactory>()
                .Include(x => x.StripFactorySchedules
                .Where(sfs => !string.IsNullOrEmpty(sfs.BatchNo) 
                    && sfs.BatchNo.ToLower().Contains(batchNo)
                    && sfs.StripScheduleId == null)).Filter(parameter);

            if (processId != null) 
                query = query.Where(x => x.Por.ProcessId == processId);
            if (!string.IsNullOrEmpty(articleName)) 
                query = query.Where(x => x.Por.ArticleName.ToLower().Contains(articleName));
            if (!string.IsNullOrEmpty(articleCode))
                query = query.Where(x => x.Por.ArticleCode.ToLower().Contains(articleCode));
            if (!string.IsNullOrEmpty(buyer))
                query = query.Where(x => x.Por.Buyer.ToLower().Contains(buyer));
            if (!string.IsNullOrEmpty(category))
                query = query.Where(x => x.Por.Category.ToLower().Contains(category));
            if (!string.IsNullOrEmpty(subCategory))
                query = query.Where(x => x.Por.SubCategory.ToLower().Contains(subCategory));
            if (!string.IsNullOrEmpty(productGroup))
                query = query.Where(x => x.Por.ProductGroup.ToLower().Contains(productGroup));
            if (!string.IsNullOrEmpty(jobOrderNo))
                query = query.Where(x => x.Por.JobOrderNo.ToLower().Contains(jobOrderNo));

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

        public async Task<StripFactory> GetByIdIncludeAsync(int id)
        {
            return await _stripFactories.Include(x => x.StripFactoryDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<TModel>> GetHistoryAsync<TModel>(string articleCode)
            where TModel : class
        {
            return await _stripFactories.Where(x => x.Por.ArticleCode == articleCode)
                                                .OrderByDescending(x => x.StartDate)
                                                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                                                .ToListAsync();
        }

        public async Task<IReadOnlyList<TModel>> GetDataForFactoryCapacities<TModel>(string porNo, DateTime startDate, DateTime endDate) where TModel : class
        {
            return await _stripFactories
                .Where(x => x.StartDate >= startDate && x.EndDate <= endDate && x.Por.PORNo == porNo)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<StripFactory>> GetStripFactoryByPlanningFactoryIds(List<int> plgIds, DateTime fDate, DateTime tDate)
        {
            return await _stripFactories.Where(x => plgIds.Contains(x.PlanningGroupFactoryId) 
                && x.StartDate.Value.Date >= fDate.Date && x.EndDate.Value.Date <= tDate.Date 
                && x.IsPlanning == false).ToListAsync();
        }
    }
}
