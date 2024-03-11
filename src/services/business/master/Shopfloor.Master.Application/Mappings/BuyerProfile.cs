using AutoMapper;
using Shopfloor.Master.Application.Command.Buyers;
using Shopfloor.Master.Application.Models.Buyers;
using Shopfloor.Master.Application.Parameters.Buyers;
using Shopfloor.Master.Application.Query.Buyers;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<Buyer, BuyerModel>().ReverseMap();
            CreateMap<CreateBuyerCommand, Buyer>();
            CreateMap<GetBuyersQuery, BuyerParameter>();
        }
    }
}
