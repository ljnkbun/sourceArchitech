using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxPorDataService
    {
        Task<List<GetWfxPorResponse>> GetWfxPorsAsync(WfxPorParameter parameter);
    }
}
