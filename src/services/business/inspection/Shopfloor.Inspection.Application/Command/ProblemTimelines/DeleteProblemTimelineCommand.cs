using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.ProblemTimelines
{
    public class DeleteProblemTimelineCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProblemTimelineCommandHandler : IRequestHandler<DeleteProblemTimelineCommand, Response<int>>
    {
        private readonly IProblemTimelineRepository _repository;
        public DeleteProblemTimelineCommandHandler(IProblemTimelineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProblemTimelineCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"ProblemTimeline Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
