using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.ProblemTimelines
{
    public class GetProblemTimelineQuery : IRequest<Response<ProblemTimeline>>
    {
        public int Id { get; set; }
    }
    public class GetProblemTimelineQueryHandler : IRequestHandler<GetProblemTimelineQuery, Response<ProblemTimeline>>
    {
        private readonly IProblemTimelineRepository _repository;
        public GetProblemTimelineQueryHandler(IProblemTimelineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProblemTimeline>> Handle(GetProblemTimelineQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"ProblemTimelines Not Found (Id:{query.Id}).");
            return new Response<ProblemTimeline>(entity);
        }
    }
}
