using AutoMapper;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Command.Measurements;
using Shopfloor.Production.Application.Models.Measurements;
using Shopfloor.Production.Application.Parameters.Measurements;
using Shopfloor.Production.Application.Query.Measurements;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Measurement, MeasurementModel>().ReverseMap();
            CreateMap<Measurement, MesurementDto>().ReverseMap();
            CreateMap<CreateMeasurementCommand, Measurement>();
            CreateMap<GetMeasurementsQuery, MeasurementParameter>();
        }
    }
}
