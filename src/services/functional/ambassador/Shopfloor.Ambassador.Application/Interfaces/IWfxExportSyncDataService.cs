using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxExportSyncDataService
    {
        Task<WfxExportSyncResponse> GetExportSyncsAsync(WfxExportSyncParameter parameter);
    }
}
