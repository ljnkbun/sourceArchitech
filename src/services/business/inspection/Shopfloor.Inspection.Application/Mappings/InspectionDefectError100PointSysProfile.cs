using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Models.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectError100PointSyss
{
    public class InspectionDefectError100PointSysProfile : Profile
    {
        public InspectionDefectError100PointSysProfile()
        {
            CreateMap<InspectionDefectError100PointSys, InspectionDefectError100PointSysModel>().ReverseMap();
            CreateMap<CreateInspectionDefectError100PointSysCommand, InspectionDefectError100PointSys>();
            CreateMap<GetInspectionDefectError100PointSyssQuery, InspectionDefectError100PointSysParameter>();
            CreateMap<UpdateInspectionDefectError100PointSysCommand, InspectionDefectError100PointSys>().ForMember(x => x.InspectionDefectCapturing100PointSysId, opt => opt.Ignore());
        }
    }
}
