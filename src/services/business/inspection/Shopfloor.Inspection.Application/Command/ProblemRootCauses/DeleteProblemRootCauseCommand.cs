using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.ProblemRootCauses
{
    public class DeleteProblemRootCauseCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProblemRootCauseCommandHandler : IRequestHandler<DeleteProblemRootCauseCommand, Response<int>>
    {
        private readonly IProblemRootCauseRepository _repository;
        public DeleteProblemRootCauseCommandHandler(IProblemRootCauseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProblemRootCauseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"ProblemRootCause Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
