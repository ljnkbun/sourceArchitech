using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingYarns;
using Shopfloor.IED.Application.Models.KnittingYarns;
using Shopfloor.IED.Application.Parameters.KnittingYarns;
using Shopfloor.IED.Application.Query.KnittingYarns;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingYarns
{
    public class KnittingYarnProfile : Profile
    {
        public KnittingYarnProfile()
        {
            CreateMap<KnittingYarn, KnittingYarnModel>().ReverseMap();
            CreateMap<CreateKnittingYarnCommand, KnittingYarn>();
            CreateMap<GetKnittingYarnsQuery, KnittingYarnParameter>();
        }
    }
}
