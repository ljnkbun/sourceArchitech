using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingFeeders;
using Shopfloor.IED.Application.Models.KnittingFeeders;
using Shopfloor.IED.Application.Parameters.KnittingFeeders;
using Shopfloor.IED.Application.Query.KnittingFeeders;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingFeeders
{
    public class KnittingFeederProfile : Profile
    {
        public KnittingFeederProfile()
        {
            CreateMap<KnittingFeeder, KnittingFeederModel>().ReverseMap();
            CreateMap<CreateKnittingFeederCommand, KnittingFeeder>();
            CreateMap<GetKnittingFeedersQuery, KnittingFeederParameter>();
        }
    }
}
