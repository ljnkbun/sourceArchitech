using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingProcessChemicals;
using Shopfloor.IED.Application.Models.DyeingProcessChemicals;
using Shopfloor.IED.Application.Parameters.DyeingProcessChemicals;
using Shopfloor.IED.Application.Query.DyeingProcessChemicals;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingProcessChemicalProfile : Profile
    {
        public DyeingProcessChemicalProfile()
        {
            CreateMap<DyeingProcessChemical, DyeingProcessChemicalModel>().ReverseMap();
            CreateMap<CreateDyeingProcessChemicalCommand, DyeingProcessChemical>();
            CreateMap<GetDyeingProcessChemicalsQuery, DyeingProcessChemicalParameter>();
        }
    }
}