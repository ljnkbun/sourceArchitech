using AutoMapper;
using Shopfloor.Planning.Application.Command.CriticalParts;
using Shopfloor.Planning.Application.Models.CriticalParts;
using Shopfloor.Planning.Application.Parameters.CriticalParts;
using Shopfloor.Planning.Application.Parameters.FPPOs;
using Shopfloor.Planning.Application.Query.CriticalParts;
using Shopfloor.Planning.Application.Query.FPPOs;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class CriticalPartProfile : Profile
    {
        public CriticalPartProfile()
        {
            CreateMap<CriticalPart, CriticalPartModel>().ReverseMap();
            CreateMap<CreateCriticalPartCommand, CriticalPart>();
            CreateMap<UpdateCriticalPartCommand, CriticalPart>();
			CreateMap<GetCriticalPartsQuery, CriticalPartParameter>();
		}
    }
}
