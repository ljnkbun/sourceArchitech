using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectCapturing4PointSyss
{
    public class InspectionDefectCapturing4PointSysProfile : Profile
    {
        public InspectionDefectCapturing4PointSysProfile()
        {
            CreateMap<InspectionDefectCapturing4PointSys, InspectionDefectCapturing4PointSysModel>().ReverseMap();
            CreateMap<CreateInspectionDefectCapturing4PointSysCommand, InspectionDefectCapturing4PointSys>();
            CreateMap<GetInspectionDefectCapturing4PointSyssQuery, InspectionDefectCapturing4PointSysParameter>();
            CreateMap<UpdateInspectionDefectCapturing4PointSysCommand, InspectionDefectCapturing4PointSys>().ForMember(x => x.Inpection4PointSysId, opt => opt.Ignore())
                                                                                          .ForMember(x => x.QCDefectId, opt => opt.Ignore());
        }
    }
}
