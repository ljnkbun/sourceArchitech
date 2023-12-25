using AutoMapper;
using Shopfloor.Master.Application.Command.YarnCompositions;
using Shopfloor.Master.Application.Models.YarnCompositions;
using Shopfloor.Master.Application.Parameters.YarnCompositions;
using Shopfloor.Master.Application.Query.YarnCompositions;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.YarnCompositions
{
    public class YarnCompositionProfile : Profile
    {
        public YarnCompositionProfile()
        {
            CreateMap<YarnComposition, YarnCompositionModel>().ReverseMap();
            CreateMap<CreateYarnCompositionCommand, YarnComposition>();
            CreateMap<GetYarnCompositionsQuery, YarnCompositionParameter>();
        }
    }
}
