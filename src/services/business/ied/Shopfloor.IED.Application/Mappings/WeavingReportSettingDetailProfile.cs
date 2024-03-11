using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingReportSettingDetails;
using Shopfloor.IED.Application.Models.WeavingReportSettingDetails;
using Shopfloor.IED.Application.Parameters.WeavingReportSettingDetails;
using Shopfloor.IED.Application.Query.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class WeavingReportSettingDetailProfile : Profile
    {
        public WeavingReportSettingDetailProfile()
        {
            CreateMap<WeavingReportSettingDetail, WeavingReportSettingDetailModel>().ReverseMap();
            CreateMap<CreateWeavingReportSettingDetailCommand, WeavingReportSettingDetail>();
            CreateMap<UpdateWeavingReportSettingDetailCommand, WeavingReportSettingDetail>();
            CreateMap<GetWeavingReportSettingDetailsQuery, WeavingReportSettingDetailParameter>();
        }
    }
}