using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Application.Models.DyeingTBRChemicals;
using Shopfloor.IED.Application.Parameters.DyeingTBRChemicals;
using Shopfloor.IED.Application.Query.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRChemicalProfile : Profile
    {
        public DyeingTBRChemicalProfile()
        {
            CreateMap<DyeingTBRChemical, DyeingTBRChemicalModel>().ReverseMap();
            CreateMap<CreateDyeingTBRChemicalCommand, DyeingTBRChemical>();
            CreateMap<UpdateDyeingTBRChemicalCommand, DyeingTBRChemical>();
            CreateMap<GetDyeingTBRChemicalsQuery, DyeingTBRChemicalParameter>();
        }
    }
}