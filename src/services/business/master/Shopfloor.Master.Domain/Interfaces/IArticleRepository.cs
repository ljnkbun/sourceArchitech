using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IArticleRepository : IGenericRepositoryAsync<Article>
    {
        Task<Article> GetArticleByIdAsync(int id);
        Task<bool> UpdateArticlesAsync(List<Article> article,
        List<ArticleBaseColor> deleteArticleBaseColors,
        List<ArticleBaseSize> deleteArticleBaseSizes,
        List<ArticleFlexField> deleteArticleFlexFields);
        Task<List<Article>> GetAllArticlesForSycnWFXAsync(string category);
        Task<Article> GetArticleByWFXIdAsync(int wfxId);
        Task<Article> GetArticleByCodeAsync(string code);
    }
}
