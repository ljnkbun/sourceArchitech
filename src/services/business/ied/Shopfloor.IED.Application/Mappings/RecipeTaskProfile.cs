using AutoMapper;
using Shopfloor.IED.Application.Command.RecipeTasks;
using Shopfloor.IED.Application.Models.RecipeTasks;
using Shopfloor.IED.Application.Parameters.RecipeTasks;
using Shopfloor.IED.Application.Query.RecipeTasks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class RecipeTaskProfile : Profile
    {
        public RecipeTaskProfile()
        {
            CreateMap<RecipeTask, RecipeTaskModel>().ReverseMap();
            CreateMap<CreateRecipeTaskCommand, RecipeTask>();
            CreateMap<GetRecipeTasksQuery, RecipeTaskParameter>();
        }
    }
}