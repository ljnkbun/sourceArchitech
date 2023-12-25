using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRVersions;
using Shopfloor.IED.Application.Models.DyeingTBRVersions;
using Shopfloor.IED.Application.Parameters.DyeingTBRVersions;
using Shopfloor.IED.Application.Query.DyeingTBRVersions;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRVersionProfile : Profile
    {
        public DyeingTBRVersionProfile()
        {
            CreateMap<DyeingTBRVersion, DyeingTBRVersionModel>().ReverseMap();
            CreateMap<CreateDyeingTBRVersionCommand, DyeingTBRVersion>();
            CreateMap<GetDyeingTBRVersionsQuery, DyeingTBRVersionParameter>();
        }
    }
}