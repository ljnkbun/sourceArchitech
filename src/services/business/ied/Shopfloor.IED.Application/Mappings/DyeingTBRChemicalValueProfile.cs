using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRChemicalValues;
using Shopfloor.IED.Application.Models.DyeingTBRChemicalValues;
using Shopfloor.IED.Application.Parameters.DyeingTBRChemicalValues;
using Shopfloor.IED.Application.Query.DyeingTBRChemicalValues;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRChemicalValueProfile : Profile
    {
        public DyeingTBRChemicalValueProfile()
        {
            CreateMap<DyeingTBRChemicalValue, DyeingTBRChemicalValueModel>().ReverseMap();
            CreateMap<CreateDyeingTBRChemicalValueCommand, DyeingTBRChemicalValue>();
            CreateMap<UpdateDyeingTBRChemicalValueCommand, DyeingTBRChemicalValue>();
            CreateMap<GetDyeingTBRChemicalValuesQuery, DyeingTBRChemicalValueParameter>();
        }
    }
}