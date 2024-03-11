using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionDefectCapturing100PointSyss
{
    public class InspectionDefectCapturing100PointSysProfile : Profile
    {
        public InspectionDefectCapturing100PointSysProfile()
        {
            CreateMap<InspectionDefectCapturing100PointSys, InspectionDefectCapturing100PointSysModel>().ReverseMap();
            CreateMap<CreateInspectionDefectCapturing100PointSysCommand, InspectionDefectCapturing100PointSys>();
            CreateMap<GetInspectionDefectCapturing100PointSyssQuery, InspectionDefectCapturing100PointSysParameter>();
            CreateMap<UpdateInspectionDefectCapturing100PointSysCommand, InspectionDefectCapturing100PointSys>().ForMember(x => x.Inpection100PointSysId, opt => opt.Ignore())
                                                                                          .ForMember(x => x.QCDefectId, opt => opt.Ignore());
        }
    }
}
