using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Services.Wfxs
{
    public interface IWfxPOArticleServices
    {
        Task<IReadOnlyList<WfxPOArticle>> GetPOArticlesAsync();
    }
}
