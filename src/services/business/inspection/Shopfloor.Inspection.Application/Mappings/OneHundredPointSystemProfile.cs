using AutoMapper;
using Shopfloor.Inspection.Application.Command.OneHundredPointSystems;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystems;
using Shopfloor.Inspection.Application.Parameters.OneHundredPointSystems;
using Shopfloor.Inspection.Application.Query.OneHundredPointSystems;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.OneHundredPointSystems
{
    public class OneHundredPointSystemProfile : Profile
    {
        public OneHundredPointSystemProfile()
        {
            CreateMap<OneHundredPointSystem, OneHundredPointSystemModel>().ReverseMap();
            CreateMap<CreateOneHundredPointSystemCommand, OneHundredPointSystem>();
            CreateMap<GetOneHundredPointSystemsQuery, OneHundredPointSystemParameter>();
        }
    }
}
