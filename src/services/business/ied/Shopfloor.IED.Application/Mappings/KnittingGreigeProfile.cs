using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingGreiges;
using Shopfloor.IED.Application.Models.KnittingGreiges;
using Shopfloor.IED.Application.Parameters.KnittingGreiges;
using Shopfloor.IED.Application.Query.KnittingGreiges;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingGreiges
{
    public class KnittingGreigeProfile : Profile
    {
        public KnittingGreigeProfile()
        {
            CreateMap<KnittingGreige, KnittingGreigeModel>().ReverseMap();
            CreateMap<CreateKnittingGreigeCommand, KnittingGreige>();
            CreateMap<GetKnittingGreigesQuery, KnittingGreigeParameter>();
        }
    }
}
