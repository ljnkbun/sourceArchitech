using AutoMapper;
using Shopfloor.Barcode.Application.Models.WfxExportSyncs;
using Shopfloor.Barcode.Application.Parameters.WfxExportSyncs;
using Shopfloor.Barcode.Application.Query.WfxExportSyncs;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class WfxExportSyncProfile : Profile
    {
        public WfxExportSyncProfile()
        {

            CreateMap<WfxExportSyncDataModel, GetWfxExportSyncData>().ReverseMap();
            CreateMap<GetWfxExportSyncsQuery, WfxExportSyncParameter>();
        }
    }
}
