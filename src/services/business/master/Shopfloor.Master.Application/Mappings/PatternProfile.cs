using AutoMapper;
using Shopfloor.Master.Application.Command.Patterns;
using Shopfloor.Master.Application.Models.Patterns;
using Shopfloor.Master.Application.Parameters.Patterns;
using Shopfloor.Master.Application.Query.Patterns;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Patterns
{
    public class PatternProfile : Profile
    {
        public PatternProfile()
        {
            CreateMap<Pattern, PatternModel>().ReverseMap();
            CreateMap<CreatePatternCommand, Pattern>();
            CreateMap<GetPatternsQuery, PatternParameter>();
        }
    }
}
