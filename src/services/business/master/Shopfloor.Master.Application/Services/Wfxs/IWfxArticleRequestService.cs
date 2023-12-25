using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Master.Application.Services.Wfxs
{
    public interface IWfxArticleRequestService
    {
        Task<List<WfxArticleDto>> SearchArticle(Dictionary<string, string> dataSearch);
    }
}
