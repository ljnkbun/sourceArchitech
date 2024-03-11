using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class UOMRepository : MasterRepositoryAsync<UOM>, IUOMRepository
    {
        public UOMRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<UOM>().AnyAsync(x => x.Id == id);
        }

        public async Task<UOM> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<UOM>()
            .Include(x => x.ProductGroupUOMs)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetUOMPagedResponseAsync<TParam, TModel>(TParam parameter, int? articleId, string articleCode) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<UOM>().Filter(parameter);
            if (articleId.HasValue)
            {
                var dataArticle = _dbContext.Set<Article>().FirstOrDefault(x => x.Id == articleId.Value);
                query = query.Where(x => x.ProductGroupUOMs.Any(y => y.ProductGroup.Name.ToLower() == dataArticle.ProductGroup.ToLower()));
            }
            if (!string.IsNullOrEmpty(articleCode))
            {
                var productGroup = _dbContext.Set<Article>().Where(x => x.ArticleCode == articleCode).Select(x => x.ProductGroup).FirstOrDefault();
                query = query.Where(x => x.ProductGroupUOMs.Any(y => y.ProductGroup.Name.ToLower() == productGroup.ToSafeLower()));
            }

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

        public async Task UpdateUOMAsync(UOM entity, BaseUpdateEntity<ProductGroupUOM> productGroupUOMs)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Set<ProductGroupUOM>().RemoveRange(productGroupUOMs.LstDataDelete);
                _dbContext.Set<ProductGroupUOM>().AddRange(productGroupUOMs.LstDataAdd);
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}