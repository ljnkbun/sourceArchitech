using Shopfloor.Ambassador.Application.Models;
using Shopfloor.EventBus.Models.Requests;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxImportSyncDataService
    {
        Task<List<WfxImportSyncResponse>> GetImportSyncsAsync(List<GetWfxImportSyncParameter> parameters);
    }
}
