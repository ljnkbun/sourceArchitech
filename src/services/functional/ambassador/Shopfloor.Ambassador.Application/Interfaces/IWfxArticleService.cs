using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxArticleService
    {
        Task<List<WfxArticle>> GetArticlesAsync(WfxArticleParameter parameter);
    }
}
