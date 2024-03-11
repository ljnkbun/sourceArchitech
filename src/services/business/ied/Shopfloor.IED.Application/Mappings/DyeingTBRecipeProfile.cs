using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Application.Models.DyeingTBRecipes;
using Shopfloor.IED.Application.Parameters.DyeingTBRecipes;
using Shopfloor.IED.Application.Query.DyeingTBRecipes;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRecipeProfile : Profile
    {
        public DyeingTBRecipeProfile()
        {
            CreateMap<DyeingTBRecipe, DyeingTBRecipeModel>().ReverseMap();
            CreateMap<CreateDyeingTBRecipeCommand, DyeingTBRecipe>();
            CreateMap<UpdateDyeingTBRecipeCommand, DyeingTBRecipe>();
            CreateMap<GetDyeingTBRecipesQuery, DyeingTBRecipeParameter>();
        }
    }
}