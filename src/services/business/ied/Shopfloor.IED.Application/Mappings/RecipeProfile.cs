using AutoMapper;
using Shopfloor.IED.Application.Command.Recipes;
using Shopfloor.IED.Application.Models.Recipes;
using Shopfloor.IED.Application.Parameters.Recipes;
using Shopfloor.IED.Application.Query.Recipes;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<CreateRecipeCommand, Recipe>();
            CreateMap<GetRecipesQuery, RecipeParameter>();
        }
    }
}