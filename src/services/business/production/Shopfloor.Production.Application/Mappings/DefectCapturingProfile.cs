using AutoMapper;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Command.DefectCapturings;
using Shopfloor.Production.Application.Models.DefectCapturings;
using Shopfloor.Production.Application.Parameters.DefectCapturings;
using Shopfloor.Production.Application.Query.DefectCapturings;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class DefectCapturingProfile : Profile
    {
        public DefectCapturingProfile()
        {
            CreateMap<DefectCapturing, DefectCapturingModel>().ReverseMap();
            CreateMap<DefectCapturing, DefectCapturingDto>().ReverseMap();
            CreateMap<CreateDefectCapturingCommand, DefectCapturing>();
            CreateMap<GetDefectCapturingsQuery, DefectCapturingParameter>();
        }
    }
}
