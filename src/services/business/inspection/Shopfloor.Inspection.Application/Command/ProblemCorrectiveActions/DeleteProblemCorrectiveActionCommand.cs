using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.ProblemCorrectiveActions
{
    public class DeleteProblemCorrectiveActionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProblemCorrectiveActionCommandHandler : IRequestHandler<DeleteProblemCorrectiveActionCommand, Response<int>>
    {
        private readonly IProblemCorrectiveActionRepository _repository;
        public DeleteProblemCorrectiveActionCommandHandler(IProblemCorrectiveActionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProblemCorrectiveActionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"ProblemCorrectiveAction Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
