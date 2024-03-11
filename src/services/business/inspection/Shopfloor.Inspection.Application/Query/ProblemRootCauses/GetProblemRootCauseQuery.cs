using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.ProblemRootCauses
{
    public class GetProblemRootCauseQuery : IRequest<Response<ProblemRootCause>>
    {
        public int Id { get; set; }
    }
    public class GetProblemRootCauseQueryHandler : IRequestHandler<GetProblemRootCauseQuery, Response<ProblemRootCause>>
    {
        private readonly IProblemRootCauseRepository _repository;
        public GetProblemRootCauseQueryHandler(IProblemRootCauseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProblemRootCause>> Handle(GetProblemRootCauseQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"ProblemRootCauses Not Found (Id:{query.Id}).");
            return new Response<ProblemRootCause>(entity);
        }
    }
}
