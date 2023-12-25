using AutoMapper;
using Shopfloor.Master.Application.Command.Ports;
using Shopfloor.Master.Application.Models.Ports;
using Shopfloor.Master.Application.Parameters.Ports;
using Shopfloor.Master.Application.Query.Ports;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Ports
{
    public class PortProfile : Profile
    {
        public PortProfile()
        {
            CreateMap<Port, PortModel>()
                .ForMember(dest => dest.CountryName, opts => opts.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.CountryCode, opts => opts.MapFrom(src => src.Country.Code))
                .ReverseMap();
            CreateMap<CreatePortCommand, Port>();
            CreateMap<GetPortsQuery, PortParameter>();
        }
    }
}
