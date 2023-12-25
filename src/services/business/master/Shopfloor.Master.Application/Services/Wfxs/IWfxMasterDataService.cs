using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Wfxs;

namespace Shopfloor.Master.Application.Services.Wfxs
{
    public interface IWfxMasterDataService
    {
        Task<WfxMasterDataResponse<WfxApiMasterData>> GetMasterData(string masterName);
    }
}
