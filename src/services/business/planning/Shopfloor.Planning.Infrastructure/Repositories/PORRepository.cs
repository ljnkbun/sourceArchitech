using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Application.Helpers;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class PORRepository : GenericRepositoryAsync<POR>, IPORRepository
    {
        private readonly DbSet<POR> _pORs;
        private readonly DbSet<MergeSplitPOR> _mergeSplitPORs;
        private readonly DbSet<MergeSplitPorDetail> _mergeSplitPorDetails;

        public PORRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _pORs = dbContext.Set<POR>();
            _mergeSplitPORs = dbContext.Set<MergeSplitPOR>();
            _mergeSplitPorDetails = dbContext.Set<MergeSplitPorDetail>();
        }

        public override async Task<POR> GetByIdAsync(int id)
        {
            return await _pORs.Include(x => x.PORDetails).Include(x => x.ToMergeSplitPORs).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<POR>> GetWfxPORByIdsAsync(List<int> ids)
        {
            return await _pORs
                .Include(x => x.PORDetails)
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<POR> MergePORAsync(ICollection<POR> mergePOR)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Create to POR
                var toPOR = mergePOR.FirstOrDefault().Clone();
                toPOR.Id = 0;
                toPOR.Quantity = mergePOR.Sum(x => (x.Quantity > x.RemainingQuantity && x.RemainingQuantity != 0) ? x.RemainingQuantity : x.Quantity);
                toPOR.RemainingQuantity = mergePOR.Sum(x => (x.Quantity > x.RemainingQuantity && x.RemainingQuantity != 0) ? x.RemainingQuantity : x.Quantity);
                toPOR.PORDetails = new List<PORDetail>();
                toPOR.JobOrderNo = await JobOrderNoRequestAsync(toPOR.ProcessName);
                toPOR.TypePOR = PorType.Merge;

                var toPORDetails = mergePOR.SelectMany(x => x.PORDetails).GroupBy(x => new { x.Size, x.Color });

                foreach (var entry in toPORDetails)
                {
                    var newDetail = entry.FirstOrDefault().Clone();
                    newDetail.Id = 0;
                    newDetail.RemainingQuantity = entry.Sum(x => (x.OrderedQuantity > x.RemainingQuantity && x.RemainingQuantity != 0) ? x.RemainingQuantity : x.OrderedQuantity);
                    newDetail.OrderedQuantity = entry.Sum(x => (x.OrderedQuantity > x.RemainingQuantity && x.RemainingQuantity != 0) ? x.RemainingQuantity : x.OrderedQuantity);
                    newDetail.TypePORDetail = PorType.Merge;

                    toPOR.PORDetails.Add(newDetail);
                }

                await _pORs.AddAsync(toPOR);

                var mergeSplitPOR = new List<MergeSplitPOR>();

                // Update from POR
                foreach (var fromPOR in mergePOR)
                {
                    fromPOR.RemainingQuantity = 0;
                    mergeSplitPOR.Add(new() { FromPOR = fromPOR, FromPORId = fromPOR.Id, ToPOR = toPOR, ToPORId = toPOR.Id, Quantity = (fromPOR.Quantity > fromPOR.RemainingQuantity && fromPOR.RemainingQuantity != 0) ? fromPOR.RemainingQuantity : fromPOR.Quantity });
                }

                var mergeSplitPorDetail = new List<MergeSplitPorDetail>();
                foreach (var item in mergePOR.SelectMany(x => x.PORDetails))
                {
                    item.RemainingQuantity = 0;

                    var toPorDetail = toPOR.PORDetails.FirstOrDefault(x => x.Size.Contains(item.Size) && x.Color.Contains(item.Color));
                    mergeSplitPorDetail.Add(new() { FromPorDetail = item, FromPorDetailId = item.Id, ToPorDetailId = toPorDetail.Id, ToPorDetail = toPorDetail, Quantity = (item.OrderedQuantity > item.RemainingQuantity && item.RemainingQuantity != 0) ? item.RemainingQuantity : item.OrderedQuantity });
                }

                _pORs.UpdateRange(mergePOR);
                await _mergeSplitPORs.AddRangeAsync(mergeSplitPOR);
                await _mergeSplitPorDetails.AddRangeAsync(mergeSplitPorDetail);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();

                return toPOR;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<POR> SplitPORAsync(POR entity, List<PORDetail> pORDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var toPOR = entity.Clone();
                toPOR.Id = 0;
                toPOR.Quantity = pORDetails.Sum(x => x.OrderedQuantity);
                toPOR.RemainingQuantity = pORDetails.Sum(x => x.OrderedQuantity);
                toPOR.PORDetails = pORDetails;
                toPOR.ToMergeSplitPORs = null;
                toPOR.TypePOR = PorType.Split;

                // Update the POR when performing Split
                foreach (var fromPORDetail in entity.PORDetails.ToList())
                {
                    if (pORDetails.Any(x => x.Color.Equals(fromPORDetail.Color) && x.Size.Equals(fromPORDetail.Size)))
                    {
                        fromPORDetail.RemainingQuantity = fromPORDetail.RemainingQuantity - pORDetails.First(x => x.Color.Equals(fromPORDetail.Color) && x.Size.Equals(fromPORDetail.Size)).OrderedQuantity;
                    }
                }

                entity.RemainingQuantity -= toPOR.RemainingQuantity;
                _pORs.Update(entity);

                // Add POR Split
                await _pORs.AddAsync(toPOR);

                // Create data in Table MergeSplitPOR
                var splitPOR = new MergeSplitPOR()
                {
                    FromPOR = entity,
                    FromPORId = entity.Id,
                    ToPOR = toPOR,
                    ToPORId = toPOR.Id,
                    Quantity = toPOR.PORDetails.Sum(x => x.OrderedQuantity),
                };

                // Create data in Table MergeSplitPORDetail
                var splitPorDetails = new List<MergeSplitPorDetail>();
                foreach (var toPorDetail in toPOR.PORDetails)
                {
                    splitPorDetails.Add(new MergeSplitPorDetail()
                    {
                        FromPorDetail = entity.PORDetails.First(x => x.Color.Equals(toPorDetail.Color) && x.Size.Equals(toPorDetail.Size)),
                        FromPorDetailId = entity.PORDetails.First(x => x.Color.Equals(toPorDetail.Color) && x.Size.Equals(toPorDetail.Size)).Id,
                        ToPorDetail = toPorDetail,
                        ToPorDetailId = toPorDetail.Id,
                        Quantity = toPorDetail.OrderedQuantity
                    });

                    toPorDetail.TypePORDetail = PorType.Split;
                }

                await _mergeSplitPORs.AddAsync(splitPOR);
                await _mergeSplitPorDetails.AddRangeAsync(splitPorDetails);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();

                return toPOR;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> SaveWfxPORSync(List<POR> entities)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var exits = await Exits();
                if (!exits)
                {
                    foreach (var item in entities)
                    {
                        item.TypePOR = PorType.ToWfx;
                    }
                    await _pORs.AddRangeAsync(entities);
                }
                else
                {
                    var delEntities = new List<POR>();

                    foreach (var item in entities)
                    {
                        var lstDelPor = _pORs.Where(x => x.PORNo == item.PORNo && x.ProcessId == item.ProcessId && x.OrderId == item.OrderId).ToList();
                        delEntities.AddRange(lstDelPor);
                        item.TypePOR = PorType.ToWfx;
                    }

                    _pORs.RemoveRange(delEntities);
                    await _pORs.AddRangeAsync(entities);
                }

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

        public async Task<List<int>> GetByArticleCode(string articleCode)
        {
            return await _pORs.Where(s => s.ArticleCode.Contains(articleCode)).Select(x => x.Id).ToListAsync();
        }

        public async Task<bool> CheckAnyArticleCodeInPor(string articleCode)
        {
            return await _pORs.AnyAsync(p => p.ArticleCode.Contains(articleCode));
        }

        public virtual async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedReponseIsRemainingAsync<TParam, TModel>(TParam parameter, bool? isRemaining)
            where TModel : class
            where TParam : RequestParameter
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<POR>().Filter(parameter);
            if (isRemaining == true)
            {
                query = query.Where(x => x.RemainingQuantity > 0);
            }
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            return response;
        }

        public async Task<POR> AddJobOrderNoRequestAsync(POR entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.JobOrderNo = await JobOrderNoRequestAsync(entity.ProcessName);
                    _dbContext.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
            return entity;
        }

        private async Task<string> JobOrderNoRequestAsync(string processName)
        {
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.JO);
            string inputValue = $"{AutoIncrementType.JO}{autoIncrement.Separate}{processName[..3]}{autoIncrement.Separate}{DateTime.Now:yy}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string jobOrderNo = "";
            bool isUnique;
            int count = 0;
            do
            {
                jobOrderNo = AutoIncrementHelper.GetNewCode(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<POR>().AllAsync(x => x.JobOrderNo != jobOrderNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return jobOrderNo;
        }

        private async Task<bool> Exits()
        {
            return await _pORs.AnyAsync();
        }
    }
}