using AutoMapper;
using Shopfloor.Barcode.Application.Models.WfxGDNs;
using Shopfloor.Barcode.Application.Parameters.WfxGDNs;
using Shopfloor.Barcode.Application.Query.WfxGDNs;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class WfxGDNProfile : Profile
    {
        public WfxGDNProfile()
        {
            CreateMap<WfxGDN, WfxGDNMasterModel>().ReverseMap();
            CreateMap<WfxGDN, WfxGDNParentModel>().ReverseMap();
            CreateMap<WfxGDN, WfxGDNChildModel>().ReverseMap();
            CreateMap<WfxGDNMasterModel, WfxGDNParentModel>().ReverseMap();
            CreateMap<WfxGDNMasterModel, WfxGDNChildModel>().ReverseMap();
            CreateMap<WfxGDNParentModel, WfxGDNChildModel>().ReverseMap();
            CreateMap<WfxGDN, GetWfxGDNDto>().ReverseMap();
            CreateMap<GetWfxGDNsQuery, WfxGDNParameter>();
        }
    }
}
