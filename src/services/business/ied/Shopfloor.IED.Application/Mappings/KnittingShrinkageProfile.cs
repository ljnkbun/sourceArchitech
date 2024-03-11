using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingShrinkages;
using Shopfloor.IED.Application.Models.KnittingShrinkages;
using Shopfloor.IED.Application.Parameters.KnittingShrinkages;
using Shopfloor.IED.Application.Query.KnittingShrinkages;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingShrinkages
{
    public class KnittingShrinkageProfile : Profile
    {
        public KnittingShrinkageProfile()
        {
            CreateMap<KnittingShrinkage, KnittingShrinkageModel>().ReverseMap();
            CreateMap<CreateKnittingShrinkageCommand, KnittingShrinkage>();
            CreateMap<GetKnittingShrinkagesQuery, KnittingShrinkageParameter>();
        }
    }
}
