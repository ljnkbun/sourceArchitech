using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.ProblemCorrectiveActions
{
    public class GetProblemCorrectiveActionQuery : IRequest<Response<ProblemCorrectiveAction>>
    {
        public int Id { get; set; }
    }
    public class GetProblemCorrectiveActionQueryHandler : IRequestHandler<GetProblemCorrectiveActionQuery, Response<ProblemCorrectiveAction>>
    {
        private readonly IProblemCorrectiveActionRepository _repository;
        public GetProblemCorrectiveActionQueryHandler(IProblemCorrectiveActionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProblemCorrectiveAction>> Handle(GetProblemCorrectiveActionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null)  return new ($"ProblemCorrectiveActions Not Found (Id:{query.Id}).");
            return new Response<ProblemCorrectiveAction>(entity);
        }
    }
}
