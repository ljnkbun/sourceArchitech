using AutoMapper;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Ambassador.Application.Query.Wfxs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxWebSharedSyncProfile : Profile
    {
        public WfxWebSharedSyncProfile()
        {
            CreateMap<WFXProductGroupSubCategoryParameter, GetWfxWebSharedDataQuery>().ReverseMap();
            CreateMap<WfxWebSharedDetailResponse, WfxWebSharedDto>().ReverseMap();
            CreateMap<WFXCommonDataGetDDLQuery, WFXGetDDLParameter>().ReverseMap();
            //CreateMap<Models.Wfxs.WFXOperationLibraryResponse, WFXOperationLibrary>().ReverseMap();
        }
    }
}
