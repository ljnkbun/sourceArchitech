using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxGDNDataService
    {
        Task<List<WfxGDNData>> GetGDNsAsync(WfxGDNParameter parameter);
    }
}
