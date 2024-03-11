using AutoMapper;
using Shopfloor.IED.Application.Command.SewingComponentGroups;
using Shopfloor.IED.Application.Models.SewingComponentGroups;
using Shopfloor.IED.Application.Parameters.SewingComponentGroups;
using Shopfloor.IED.Application.Query.SewingComponentGroups;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingComponentGroups
{
    public class SewingComponentGroupProfile : Profile
    {
        public SewingComponentGroupProfile()
        {
            CreateMap<SewingComponentGroup, SewingComponentGroupModel>().ReverseMap();
            CreateMap<CreateSewingComponentGroupCommand, SewingComponentGroup>();
            CreateMap<GetSewingComponentGroupsQuery, SewingComponentGroupParameter>();
        }
    }
}
