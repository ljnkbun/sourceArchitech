using AutoMapper;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxExportSyncProfile : Profile
    {
        public WfxExportSyncProfile()
        {
            ValueTransformers.Add<string>(val => val ?? "");
            CreateMap<WfxExportSyncParameter, GetWfxExportSyncRequest>().ReverseMap();
            CreateMap<GetWfxExportSyncQuery, WfxExportSyncParameter>().ReverseMap();
            CreateMap<WfxExportSyncResponse, GetWfxExportSyncResponse>().ReverseMap();
            CreateMap<WFXAPIGeneratePLTData, GetWfxExportSyncData>().ReverseMap();
        }
    }
}
