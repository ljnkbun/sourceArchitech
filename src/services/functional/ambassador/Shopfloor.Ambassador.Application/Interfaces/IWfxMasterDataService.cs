using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxMasterDataService
    {
        Task<List<WfxMasterData>> GetMasterDataAsync(WfxMasterDataParameter parameter);
    }
}
