using AutoMapper;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;
using Shopfloor.Inspection.Application.Models.InspectionBySizes;
using Shopfloor.Inspection.Application.Parameters.InspectionBySizes;
using Shopfloor.Inspection.Application.Query.InspectionBySizes;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InspectionBySizes
{
    public class InspectionBySizeProfile : Profile
    {
        public InspectionBySizeProfile()
        {
            CreateMap<InspectionBySize, InspectionBySizeModel>().ReverseMap();
            CreateMap<CreateInspectionBySizeCommand, InspectionBySize>();
            CreateMap<GetInspectionBySizesQuery, InspectionBySizeParameter>();
            CreateMap<UpdateInspectionBySizeCommand, InspectionBySize>().ForMember(x => x.InspectionId, opt => opt.Ignore())
                                                                        .ForMember(x=>x.QCRequestDetailId,opt => opt.Ignore());
        }
    }
}
