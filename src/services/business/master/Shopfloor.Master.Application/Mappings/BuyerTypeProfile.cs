using AutoMapper;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Application.Models.BuyerTypes;
using Shopfloor.Master.Application.Parameters.BuyerTypes;
using Shopfloor.Master.Application.Query.BuyerTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.BuyerTypes
{
    public class BuyerTypeProfile : Profile
    {
        public BuyerTypeProfile()
        {
            CreateMap<BuyerType, BuyerTypeModel>().ReverseMap();
            CreateMap<CreateBuyerTypeCommand, BuyerType>();
            CreateMap<GetBuyerTypesQuery, BuyerTypeParameter>();
        }
    }
}
