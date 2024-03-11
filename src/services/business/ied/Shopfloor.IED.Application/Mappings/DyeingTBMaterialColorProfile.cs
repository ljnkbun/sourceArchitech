using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Models.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Query.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBMaterialColorProfile : Profile
    {
        public DyeingTBMaterialColorProfile()
        {
            CreateMap<DyeingTBMaterialColor, DyeingTBMaterialColorModel>().ReverseMap();
            CreateMap<CreateDyeingTBMaterialColorCommand, DyeingTBMaterialColor>();
            CreateMap<UpdateDyeingTBMaterialColorCommand, DyeingTBMaterialColor>();
            CreateMap<GetDyeingTBMaterialColorsQuery, DyeingTBMaterialColorParameter>();
            CreateMap<GetDyeingTBMaterialColorSearchesQuery, DyeingTBMaterialColorSearchParameter>();
        }
    }
}