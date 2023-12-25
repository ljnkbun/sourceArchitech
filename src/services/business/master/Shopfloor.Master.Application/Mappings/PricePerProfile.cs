using AutoMapper;
using Shopfloor.Master.Application.Command.PricePers;
using Shopfloor.Master.Application.Models.PricePers;
using Shopfloor.Master.Application.Parameters.PricePers;
using Shopfloor.Master.Application.Query.PricePers;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class PricePerProfile : Profile
    {
        public PricePerProfile()
        {
            CreateMap<PricePer, PricePerModel>().ReverseMap();
            CreateMap<CreatePricePerCommand, PricePer>();
            CreateMap<GetPricePersQuery, PricePerParameter>();
        }
    }
}
