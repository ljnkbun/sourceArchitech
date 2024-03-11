using AutoMapper;
using Shopfloor.Planning.Application.Models.LearningCurveEfficiencies;
using Shopfloor.Planning.Application.Parameters.LearningCurveEfficiencies;
using Shopfloor.Planning.Application.Query.LearningCurveEfficiencies;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.LearningCurveEfficiencies
{
    public class LearningCurveEfficiencyProfile : Profile
    {
        public LearningCurveEfficiencyProfile()
        {
            CreateMap<LearningCurveEfficiency, LearningCurveEfficiencyModel>().ReverseMap();
            CreateMap<CreateLearningCurveEfficiencyCommand, LearningCurveEfficiency>();
            CreateMap<GetLearningCurveEfficienciesQuery, LearningCurveEfficiencyParameter>();
        }
    }
}
