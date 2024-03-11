using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Interfaces
{
    public interface IWfxWebSharedService
    {
        Task<WFXWebSharedResponse<List<WfxWebSharedDetailResponse>>> WFXProductGroupSubCategorySync(WFXProductGroupSubCategoryParameter parameter);
        Task<WFXWebSharedResponse<List<WFXOperationLibrary>>> WFXGetDDLOperationLibrary(WFXGetDDLParameter parameter);
    }
}
