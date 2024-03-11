using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTasks
{
    public class DeleteProcessTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProcessTaskCommandHandler : IRequestHandler<DeleteProcessTaskCommand, Response<int>>
    {
        private readonly IProcessTaskRepository _repository;
        public DeleteProcessTaskCommandHandler(IProcessTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProcessTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProcessTask Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
