using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectCapturingTCStandards
{
    public class InspectionDefectCapturingTCStandardProfile : Profile
    {
        public InspectionDefectCapturingTCStandardProfile()
        {
            CreateMap<InspectionDefectCapturingTCStandard, InspectionDefectCapturingTCStandardModel>().ReverseMap();
            CreateMap<CreateInspectionDefectCapturingTCStandardCommand, InspectionDefectCapturingTCStandard>();
            CreateMap<GetInspectionDefectCapturingTCStandardsQuery, InspectionDefectCapturingTCStandardParameter>();
            CreateMap<UpdateInspectionDefectCapturingTCStandardCommand, InspectionDefectCapturingTCStandard>().ForMember(x => x.InpectionTCStandardId, opt => opt.Ignore())
                                                                                          .ForMember(x => x.QCDefectId, opt => opt.Ignore());
        }
    }
}
