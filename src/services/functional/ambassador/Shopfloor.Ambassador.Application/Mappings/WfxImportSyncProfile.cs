using AutoMapper;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxImportSyncProfile : Profile
    {
        public WfxImportSyncProfile()
        {
            ValueTransformers.Add<string>(val => val ?? "");
            CreateMap<GetWfxImportSyncQuery, WfxImportSyncParameter>().ReverseMap();
            CreateMap<Models.WfxArticleFlexField, EventBus.Models.Responses.WfxArticleFlexField>().ReverseMap();
            CreateMap<EventBus.Models.Responses.Roll, Models.Roll>(); 
            CreateMap<GetWfxImportSyncData, WfxImportSyncResponse>();
            CreateMap<WfxImportSyncParameter, GetWfxImportSyncParameter>()
                .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.WFXArticleCode));
        }
    }
}
