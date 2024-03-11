using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;
using Shopfloor.Inspection.Application.Models.InspectionMesurements;
using Shopfloor.Inspection.Application.Parameters.InspectionMesurements;
using Shopfloor.Inspection.Application.Query.InspectionMesurements;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionMesurements
{
    public class InspectionMesurementProfile : Profile
    {
        public InspectionMesurementProfile()
        {
            CreateMap<InspectionMesurement, InspectionMesurementModel>().ReverseMap();
            CreateMap<CreateInspectionMesurementCommand, InspectionMesurement>();
            CreateMap<GetInspectionMesurementsQuery, InspectionMesurementParameter>();
            CreateMap<UpdateInspectionMesurementCommand, InspectionMesurement>().ForMember(x => x.InspectionId, opt => opt.Ignore())
                                                                                .ForMember(x => x.QCDefectId, opt => opt.Ignore());
        }
    }
}
