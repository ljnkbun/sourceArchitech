using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingBodyTypes;
using Shopfloor.IED.Application.Models.KnittingBodyTypes;
using Shopfloor.IED.Application.Parameters.KnittingBodyTypes;
using Shopfloor.IED.Application.Query.KnittingBodyTypes;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingBodyTypes
{
    public class KnittingBodyTypeProfile : Profile
    {
        public KnittingBodyTypeProfile()
        {
            CreateMap<KnittingBodyType, KnittingBodyTypeModel>().ReverseMap();
            CreateMap<CreateKnittingBodyTypeCommand, KnittingBodyType>();
            CreateMap<GetKnittingBodyTypesQuery, KnittingBodyTypeParameter>();
        }
    }
}
