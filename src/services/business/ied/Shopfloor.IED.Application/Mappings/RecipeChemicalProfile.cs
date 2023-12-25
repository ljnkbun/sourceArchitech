using AutoMapper;
using Shopfloor.IED.Application.Command.RecipeChemicals;
using Shopfloor.IED.Application.Models.RecipeChemicals;
using Shopfloor.IED.Application.Parameters.RecipeChemicals;
using Shopfloor.IED.Application.Query.RecipeChemicals;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class RecipeChemicalProfile : Profile
    {
        public RecipeChemicalProfile()
        {
            CreateMap<RecipeChemical, RecipeChemicalModel>().ReverseMap();
            CreateMap<CreateRecipeChemicalCommand, RecipeChemical>();
            CreateMap<GetRecipeChemicalsQuery, RecipeChemicalParameter>();
        }
    }
}