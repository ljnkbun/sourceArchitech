using AutoMapper;
using Shopfloor.Master.Application.Command.Gauges;
using Shopfloor.Master.Application.Models.Gauges;
using Shopfloor.Master.Application.Parameters.Gauges;
using Shopfloor.Master.Application.Query.Gauges;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Gauges
{
    public class GaugeProfile : Profile
    {
        public GaugeProfile()
        {
            CreateMap<Gauge, GaugeModel>().ReverseMap();
            CreateMap<CreateGaugeCommand, Gauge>();
            CreateMap<GetGaugesQuery, GaugeParameter>();
        }
    }
}
