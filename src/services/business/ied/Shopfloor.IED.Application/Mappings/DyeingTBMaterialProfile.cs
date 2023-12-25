using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBMaterials;
using Shopfloor.IED.Application.Models.DyeingTBMaterials;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterials;
using Shopfloor.IED.Application.Query.DyeingTBMaterials;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBMaterialProfile : Profile
    {
        public DyeingTBMaterialProfile()
        {
            CreateMap<DyeingTBMaterial, DyeingTBMaterialModel>().ReverseMap();
            CreateMap<CreateDyeingTBMaterialCommand, DyeingTBMaterial>();
            CreateMap<GetDyeingTBMaterialsQuery, DyeingTBMaterialParameter>();
        }
    }
}