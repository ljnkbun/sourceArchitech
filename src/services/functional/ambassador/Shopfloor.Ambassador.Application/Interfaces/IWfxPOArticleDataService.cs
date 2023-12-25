using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxPOArticleDataService
    {
        Task<List<WfxPOArticleData>> GetPOArticlesAsync(WfxPOArticleParameter parameter);
    }
}
