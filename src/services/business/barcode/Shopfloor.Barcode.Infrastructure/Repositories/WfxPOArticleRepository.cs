using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class WfxPOArticleRepository : GenericRepositoryAsync<WfxPOArticle>, IWfxPOArticleRepository
    {
        private readonly DbSet<WfxPOArticle> _wfxPOArticles;
        public WfxPOArticleRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxPOArticles = dbContext.Set<WfxPOArticle>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _wfxPOArticles.Filter(parameter);
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.POCreationDate.HasValue && x.POCreationDate.Value.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.POCreationDate.HasValue && x.POCreationDate.Value.Date <= toDate.Value.Date);
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

        public async Task<bool> Existed()
        {
            return await _wfxPOArticles.AnyAsync(x => x.PONo != null && x.POCreationDate != null);
        }

        public async Task SaveWfxPOArticleSync(List<WfxPOArticle> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var groupBy = entites.GroupBy(x => new { x.ArticleCode, x.OrderRefNum, x.PONo }).Select(x => x.Key);

                var adds = new List<WfxPOArticle>();
                var deletes = new List<WfxPOArticle>();

                foreach (var entry in groupBy)
                {
                    var anyHistory = await _wfxPOArticles.AnyAsync(x => x.ArticleCode == entry.ArticleCode && x.OrderRefNum == entry.OrderRefNum && x.PONo == entry.PONo);
                    if (!anyHistory)
                        adds.AddRange(entites.Where(x => x.ArticleCode == entry.ArticleCode && x.OrderRefNum == entry.OrderRefNum && x.PONo == entry.PONo));
                }
                await _wfxPOArticles.AddRangeAsync(adds);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }
        }

        public async Task<DateTime> GetLastDate()
        {
            return await _wfxPOArticles.MaxAsync(x => x.POCreationDate) ?? DateTime.Now;
        }

        public async Task<ICollection<WfxPOArticle>> GetByArticleCodeOrderRefAsync(string articleCode, string orderRefNum)
        {
            return await _wfxPOArticles.Where(x => x.ArticleCode == articleCode && x.OrderRefNum == orderRefNum).ToListAsync();
        }

        public async Task<ICollection<WfxPOArticle>> GetByOrderRefsAsync(string[] orderRefNums)
        {
            return await _wfxPOArticles.Where(x => orderRefNums.Contains(x.OrderRefNum)).ToListAsync();
        }
    }
}
