using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingTypes;
using Shopfloor.IED.Application.Models.KnittingTypes;
using Shopfloor.IED.Application.Parameters.KnittingTypes;
using Shopfloor.IED.Application.Query.KnittingTypes;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingTypes
{
    public class KnittingTypeProfile : Profile
    {
        public KnittingTypeProfile()
        {
            CreateMap<KnittingType, KnittingTypeModel>().ReverseMap();
            CreateMap<CreateKnittingTypeCommand, KnittingType>();
            CreateMap<GetKnittingTypesQuery, KnittingTypeParameter>();
        }
    }
}
