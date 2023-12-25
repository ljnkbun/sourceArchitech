using AutoMapper;
using Shopfloor.Master.Application.Command.ColorDefinitions;
using Shopfloor.Master.Application.Models.ColorDefinitions;
using Shopfloor.Master.Application.Parameters.ColorDefinitions;
using Shopfloor.Master.Application.Query.ColorDefinitions;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ColorDefinitionProfile : Profile
    {
        public ColorDefinitionProfile()
        {
            CreateMap<ColorDefinition, ColorDefinitionModel>().ReverseMap();
            CreateMap<CreateColorDefinitionCommand, ColorDefinition>();
            CreateMap<GetColorDefinitionsQuery, ColorDefinitionParameter>();
        }
    }
}
