using AutoMapper;
using Shopfloor.Inspection.Application.Command.Inspections;
using Shopfloor.Inspection.Application.Models.Inspections;
using Shopfloor.Inspection.Application.Parameters.Inspections;
using Shopfloor.Inspection.Application.Query.Inspections;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Inspections
{
    public class InspectionProfile : Profile
    {
        public InspectionProfile()
        {
            CreateMap<Shopfloor.Inspection.Domain.Entities.Inspection, InspectionModel>().ReverseMap();
            CreateMap<CreateInspectionCommand, Shopfloor.Inspection.Domain.Entities.Inspection>();
            CreateMap<GetInspectionsQuery, InspectionParameter>();
        }
    }
}
