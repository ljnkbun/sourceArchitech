using AutoMapper;
using Shopfloor.IED.Application.Command.RecipeUnits;
using Shopfloor.IED.Application.Models.RecipeUnits;
using Shopfloor.IED.Application.Parameters.RecipeUnits;
using Shopfloor.IED.Application.Query.RecipeUnits;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RecipeUnits
{
    public class RecipeUnitProfile : Profile
    {
        public RecipeUnitProfile()
        {
            CreateMap<RecipeUnit, RecipeUnitModel>().ReverseMap();
            CreateMap<CreateRecipeUnitCommand, RecipeUnit>();
            CreateMap<GetRecipeUnitsQuery, RecipeUnitParameter>();
        }
    }
}
