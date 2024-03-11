using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxGDIDataService
    {
        Task<List<WfxGDIData>> GetGDIsAsync(WfxGDIParameter parameter);
    }
}
