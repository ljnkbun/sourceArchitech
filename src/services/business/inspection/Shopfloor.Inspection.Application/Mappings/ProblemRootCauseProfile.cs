using AutoMapper;
using Shopfloor.Inspection.Application.Command.ProblemRootCauses;
using Shopfloor.Inspection.Application.Models.ProblemRootCauses;
using Shopfloor.Inspection.Application.Parameters.ProblemRootCauses;
using Shopfloor.Inspection.Application.Query.ProblemRootCauses;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.ProblemRootCauses
{
    public class ProblemRootCauseProfile : Profile
    {
        public ProblemRootCauseProfile()
        {
            CreateMap<ProblemRootCause, ProblemRootCauseModel>().ReverseMap();
            CreateMap<CreateProblemRootCauseCommand, ProblemRootCause>();
            CreateMap<GetProblemRootCausesQuery, ProblemRootCauseParameter>();
        }
    }
}
