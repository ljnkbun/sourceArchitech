using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRCValues;
using Shopfloor.IED.Application.Models.DyeingTBRCValues;
using Shopfloor.IED.Application.Parameters.DyeingTBRCValues;
using Shopfloor.IED.Application.Query.DyeingTBRCValues;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRCValueProfile : Profile
    {
        public DyeingTBRCValueProfile()
        {
            CreateMap<DyeingTBRCValue, DyeingTBRCValueModel>().ReverseMap();
            CreateMap<CreateDyeingTBRCValueCommand, DyeingTBRCValue>();
            CreateMap<GetDyeingTBRCValuesQuery, DyeingTBRCValueParameter>();
        }
    }
}