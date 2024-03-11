using AutoMapper;
using Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails;
using Shopfloor.Planning.Application.Models.StripFactoryScheduleDetails;
using Shopfloor.Planning.Application.Parameters.StripFactoryScheduleDetails;
using Shopfloor.Planning.Application.Query.StripFactoryScheduleDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.StripFactoryScheduleDetails
{
    public class StripFactoryScheduleDetailProfile : Profile
    {
        public StripFactoryScheduleDetailProfile()
        {
            CreateMap<StripFactoryScheduleDetail, StripFactoryScheduleDetailModel>().ReverseMap();
            CreateMap<StripFactoryScheduleDetailModel, CalculateStripFactoryScheduleDetailModel>().ReverseMap();
            CreateMap<CreateStripFactoryScheduleDetailCommand, StripFactoryScheduleDetail>();
            CreateMap<GetStripFactoryScheduleDetailsQuery, StripFactoryScheduleDetailParameter>();
        }
    }
}
