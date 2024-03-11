using AutoMapper;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Command.DefectCapturingStandards;
using Shopfloor.Production.Application.Models.DefectCapturingStandards;
using Shopfloor.Production.Application.Parameters.DefectCapturingStandards;
using Shopfloor.Production.Application.Query.DefectCapturingStandards;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class DefectCapturingStandardProfile : Profile
    {
        public DefectCapturingStandardProfile()
        {
            CreateMap<DefectCapturingStandard, DefectCapturingStandardModel>().ReverseMap();
            CreateMap<DefectCapturingStandard, DefectCapturingStandardDto>().ReverseMap();
            CreateMap<CreateDefectCapturingStandardCommand, DefectCapturingStandard>();
            CreateMap<GetDefectCapturingStandardsQuery, DefectCapturingStandardParameter>();
        }
    }
}
