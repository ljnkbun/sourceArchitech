using AutoMapper;
using Shopfloor.Planning.Application.Models.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Application.Parameters.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Application.Query.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.LearningCurveDetailEfficiencies
{
    public class LearningCurveDetailProfileEfficiency : Profile
    {
        public LearningCurveDetailProfileEfficiency()
        {
            CreateMap<LearningCurveDetailEfficiency, LearningCurveDetailEfficiencyModel>().ReverseMap();
            CreateMap<CreateLearningCurveDetailEfficiencyCommand, LearningCurveDetailEfficiency>();
            CreateMap<GetLearningCurveDetailEfficienciesQuery, LearningCurveDetailEfficiencyParameter>();
        }
    }
}
