using AutoMapper;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;
using Shopfloor.Planning.Application.Models.StripFactoryDetails;
using Shopfloor.Planning.Application.Parameters.StripFactoryDetails;
using Shopfloor.Planning.Application.Query.StripFactoryDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class StripFactoryDetailProfile : Profile
    {
        public StripFactoryDetailProfile()
        {
            CreateMap<StripFactoryDetail, StripFactoryDetailModel>().ReverseMap();
            CreateMap<StripFactoryDetailModel, CalculateStripFactoryDetailModel>().ReverseMap();
            CreateMap<StripFactoryDetail, UpdateStripFactoryDetailCommand>().ReverseMap();
            CreateMap<CreateStripFactoryDetailCommand, StripFactoryDetail>();
            CreateMap<GetStripFactoryDetailsQuery, StripFactoryDetailParameter>();
        }
    }
}
