using AutoMapper;
using Shopfloor.Inspection.Application.Command.ProblemTimelines;
using Shopfloor.Inspection.Application.Models.ProblemTimelines;
using Shopfloor.Inspection.Application.Parameters.ProblemTimelines;
using Shopfloor.Inspection.Application.Query.ProblemTimelines;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.ProblemTimelines
{
    public class ProblemTimelineProfile : Profile
    {
        public ProblemTimelineProfile()
        {
            CreateMap<ProblemTimeline, ProblemTimelineModel>().ReverseMap();
            CreateMap<CreateProblemTimelineCommand, ProblemTimeline>();
            CreateMap<GetProblemTimelinesQuery, ProblemTimelineParameter>();
        }
    }
}
