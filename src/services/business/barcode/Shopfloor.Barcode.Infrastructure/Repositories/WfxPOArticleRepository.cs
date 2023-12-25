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
                query = query.Where(x => x.OrderCreationDate.HasValue && x.OrderCreationDate.Value.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.OrderCreationDate.HasValue && x.OrderCreationDate.Value.Date <= toDate.Value.Date);
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
            return await _wfxPOArticles.AnyAsync();
        }

        public async Task SaveWfxPOArticleSync(List<WfxPOArticle> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var groupArticleCode = entites.GroupBy(x => x.ArticleCode).Select(x => x.Key);

                var delEntities = new List<WfxPOArticle>();

                foreach (var articleCode in groupArticleCode)
                {
                    var lstDelByArticleCode = await _wfxPOArticles.Where(x => x.ArticleCode == articleCode).ToListAsync();
                    delEntities.AddRange(lstDelByArticleCode);
                }

                _wfxPOArticles.RemoveRange(delEntities);
                await _wfxPOArticles.AddRangeAsync(entites);

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
            return await _wfxPOArticles.MaxAsync(x => x.OrderCreationDate) ?? DateTime.Now;
        }
    }
}
