using AutoMapper;
using Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Parameters.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Query.StripSchedulePlanningDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class StripSchedulePlanningDetailProfile : Profile
    {
        public StripSchedulePlanningDetailProfile()
        {
            CreateMap<StripSchedulePlanningDetail, StripSchedulePlanningDetailModel>();
            CreateMap<CreateStripSchedulePlanningDetailCommand, StripSchedulePlanningDetail>();
            CreateMap<UpdateStripSchedulePlanningDetailCommand, StripSchedulePlanningDetail>();
            CreateMap<GetStripSchedulePlanningDetailsQuery, StripSchedulePlanningDetailParameter>();
        }
    }
}
