using AutoMapper;
using Shopfloor.Inspection.Application.Command.ProblemCorrectiveActions;
using Shopfloor.Inspection.Application.Models.ProblemCorrectiveActions;
using Shopfloor.Inspection.Application.Parameters.ProblemCorrectiveActions;
using Shopfloor.Inspection.Application.Query.ProblemCorrectiveActions;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.ProblemCorrectiveActions
{
    public class ProblemCorrectiveActionProfile : Profile
    {
        public ProblemCorrectiveActionProfile()
        {
            CreateMap<ProblemCorrectiveAction, ProblemCorrectiveActionModel>().ReverseMap();
            CreateMap<CreateProblemCorrectiveActionCommand, ProblemCorrectiveAction>();
            CreateMap<GetProblemCorrectiveActionsQuery, ProblemCorrectiveActionParameter>();
        }
    }
}
