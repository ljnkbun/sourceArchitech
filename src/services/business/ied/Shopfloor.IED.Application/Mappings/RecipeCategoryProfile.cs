using AutoMapper;
using Shopfloor.IED.Application.Command.RecipeCategories;
using Shopfloor.IED.Application.Models.RecipeCategories;
using Shopfloor.IED.Application.Parameters.RecipeCategories;
using Shopfloor.IED.Application.Query.RecipeCategories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RecipeCategories
{
    public class RecipeCategoryProfile : Profile
    {
        public RecipeCategoryProfile()
        {
            CreateMap<RecipeCategory, RecipeCategoryModel>().ReverseMap();
            CreateMap<CreateRecipeCategoryCommand, RecipeCategory>();
            CreateMap<GetRecipeCategorysQuery, RecipeCategoryParameter>();
        }
    }
}
