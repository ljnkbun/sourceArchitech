using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Models.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectError4PointSyss
{
    public class InspectionDefectError4PointSysProfile : Profile
    {
        public InspectionDefectError4PointSysProfile()
        {
            CreateMap<InspectionDefectError4PointSys, InspectionDefectError4PointSysModel>().ReverseMap();
            CreateMap<CreateInspectionDefectError4PointSysCommand, InspectionDefectError4PointSys>();
            CreateMap<GetInspectionDefectError4PointSyssQuery, InspectionDefectError4PointSysParameter>();
            CreateMap<UpdateInspectionDefectError4PointSysCommand, InspectionDefectError4PointSys>().ForMember(x => x.InspectionDefectCapturing4PointSysId, opt => opt.Ignore());
        }
    }
}
