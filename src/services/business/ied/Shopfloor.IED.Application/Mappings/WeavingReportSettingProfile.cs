using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingReportSettings;
using Shopfloor.IED.Application.Models.WeavingReportSettings;
using Shopfloor.IED.Application.Parameters.WeavingReportSettings;
using Shopfloor.IED.Application.Query.WeavingReportSettings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class WeavingReportSettingProfile : Profile
    {
        public WeavingReportSettingProfile()
        {
            CreateMap<WeavingReportSetting, WeavingReportSettingModel>().ReverseMap();
            CreateMap<CreateWeavingReportSettingCommand, WeavingReportSetting>();
            CreateMap<UpdateWeavingReportSettingCommand, WeavingReportSetting>();
            CreateMap<GetWeavingReportSettingsQuery, WeavingReportSettingParameter>();
        }
    }
}