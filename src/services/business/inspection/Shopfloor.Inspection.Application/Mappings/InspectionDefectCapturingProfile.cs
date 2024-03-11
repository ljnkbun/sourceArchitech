using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturings;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectCapturings
{
    public class InspectionDefectCapturingProfile : Profile
    {
        public InspectionDefectCapturingProfile()
        {
            CreateMap<InspectionDefectCapturing, InspectionDefectCapturingModel>().ReverseMap();
            CreateMap<CreateInspectionDefectCapturingCommand, InspectionDefectCapturing>();
            CreateMap<GetInspectionDefectCapturingsQuery, InspectionDefectCapturingParameter>();
            CreateMap<UpdateInspectionDefectCapturingCommand, InspectionDefectCapturing>().ForMember(x => x.InspectionId, opt => opt.Ignore())
                                                                                          .ForMember(x => x.QCDefectId, opt => opt.Ignore());
        }
    }
}
