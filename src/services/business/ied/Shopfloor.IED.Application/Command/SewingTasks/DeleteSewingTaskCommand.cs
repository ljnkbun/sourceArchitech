using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingTasks
{
    public class DeleteSewingTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingTaskCommandHandler : IRequestHandler<DeleteSewingTaskCommand, Response<int>>
    {
        private readonly ISewingTaskRepository _repository;
        public DeleteSewingTaskCommandHandler(ISewingTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingTask Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
