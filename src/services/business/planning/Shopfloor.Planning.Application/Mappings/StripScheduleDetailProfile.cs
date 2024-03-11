using AutoMapper;
using Shopfloor.Planning.Application.Command.StripScheduleDetails;
using Shopfloor.Planning.Application.Models.StripScheduleDetails;
using Shopfloor.Planning.Application.Parameters.StripScheduleDetails;
using Shopfloor.Planning.Application.Query.StripScheduleDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class StripScheduleDetailProfile : Profile
    {
        public StripScheduleDetailProfile()
        {
            CreateMap<StripScheduleDetail, StripScheduleDetailModel>();
            CreateMap<CreateStripScheduleDetailCommand, StripScheduleDetail>();
            CreateMap<UpdateStripScheduleDetailCommand, StripScheduleDetail>();
            CreateMap<GetStripScheduleDetailsQuery, StripScheduleDetailParameter>();
        }
    }
}
