using AutoMapper;
using Shopfloor.IED.Application.Command.SewingComponents;
using Shopfloor.IED.Application.Models.SewingComponents;
using Shopfloor.IED.Application.Parameters.SewingComponents;
using Shopfloor.IED.Application.Query.SewingComponents;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingComponents
{
    public class SewingComponentProfile : Profile
    {
        public SewingComponentProfile()
        {
            CreateMap<SewingComponent, SewingComponentModel>().ReverseMap();
            CreateMap<CreateSewingComponentCommand, SewingComponent>();
            CreateMap<GetSewingComponentsQuery, SewingComponentParameter>();
        }
    }
}
