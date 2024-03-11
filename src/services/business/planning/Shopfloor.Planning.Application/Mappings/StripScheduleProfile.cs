using AutoMapper;
using Shopfloor.Planning.Application.Command.StripSchedules;
using Shopfloor.Planning.Application.Models.StripSchedules;
using Shopfloor.Planning.Application.Parameters.StripSchedules;
using Shopfloor.Planning.Application.Query.StripSchedules;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class StripScheduleProfile : Profile
    {
        public StripScheduleProfile()
        {
            CreateMap<StripSchedule, StripScheduleModel>();
            CreateMap<CreateStripScheduleCommand, StripSchedule>();
            CreateMap<SaveStripSchedulesCommand, StripSchedule>();
            CreateMap<UpdateStripScheduleCommand, StripSchedule>();
            CreateMap<GetStripSchedulesQuery, StripScheduleParameter>();
            CreateMap<GetStripSchedulesQuery, StripScheduleParameter>();
            CreateMap<StripScheduleDetail, StripScheduleDetailCapture>();
            CreateMap<StripSchedulePlanningDetail, StripSchedulePlanningDetailCapture>();
            CreateMap<StripSchedule, StripScheduleCapture>()
                .ForMember(dest => dest.StripScheduleDetailCaptures, opt => opt.MapFrom(src => src.StripScheduleDetails))
                .ForMember(dest => dest.StripSchedulePlanningDetailCaptures, opt => opt.MapFrom(src => src.StripSchedulePlanningDetails));
        }
    }
}
