using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ArticleRepository : GenericRepositoryAsync<Article>, IArticleRepository
    {

        public ArticleRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _dbContext.Set<Article>()
                .Include(r => r.BaseColorList)
                .Include(r => r.BaseSizeList)
                .Include(r => r.FlexFieldList)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<List<Article>> GetArticlesByIdsAsync(List<int> ids)
        {
            return await _dbContext.Set<Article>()
                .Include(r => r.BaseColorList)
                .Include(r => r.BaseSizeList)
                .Include(r => r.FlexFieldList)
                .Where(r => ids.Contains(r.WFXArticleId))
                .ToListAsync();
        }

        public async Task<ICollection<Article>> GetByArticleCodeAsync(ICollection<string> articleCode)
        {
            return await _dbContext.Set<Article>()
                .Include(r => r.BaseColorList)
                .Include(r => r.BaseSizeList)
                .Include(r => r.FlexFieldList)
                .Where(r => r.ArticleCode != null && articleCode.Contains(r.ArticleCode))
                .ToListAsync();
        }

        public async Task<Article> GetArticleByWFXIdAsync(int wfxId)
        {
            return await _dbContext.Set<Article>()
                .Include(r => r.BaseColorList)
                .Include(r => r.BaseSizeList)
                .Include(r => r.FlexFieldList)
                .FirstOrDefaultAsync(r => r.WFXArticleId == wfxId);
        }
        public async Task<Article> GetArticleByCodeAsync(string code)
        {
            return await _dbContext.Set<Article>()
                .Include(r => r.BaseColorList)
                .Include(r => r.BaseSizeList)
                .Include(r => r.FlexFieldList)
                .FirstOrDefaultAsync(r => r.ArticleCode.Equals(code));
        }
        public async Task<bool> UpdateArticlesAsync(List<Article> updateList,
          List<ArticleBaseColor> deleteArticleBaseColors,
          List<ArticleBaseSize> deleteArticleBaseSizes,
          List<ArticleFlexField> deleteArticleFlexFields)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteArticleBaseColors != null && deleteArticleBaseColors.Count > 0)
                        _dbContext.Set<ArticleBaseColor>().RemoveRange(deleteArticleBaseColors);

                    if (deleteArticleBaseSizes != null && deleteArticleBaseSizes.Count > 0)
                        _dbContext.Set<ArticleBaseSize>().RemoveRange(deleteArticleBaseSizes);

                    if (deleteArticleFlexFields != null && deleteArticleFlexFields.Count > 0)
                        _dbContext.Set<ArticleFlexField>().RemoveRange(deleteArticleFlexFields);

                    _dbContext.Set<Article>().UpdateRange(updateList);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }
        public async Task<List<Article>> GetAllArticlesForSycnWFXAsync(string category)
        {
            return await _dbContext.Set<Article>().Where(x => x.Category == category)
              .Include(r => r.BaseColorList)
              .Include(r => r.BaseSizeList)
              .Include(r => r.FlexFieldList)
              .AsNoTracking().ToListAsync();
        }
    }
}
