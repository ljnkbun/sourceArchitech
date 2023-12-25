using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Processes
{
    public class DeleteProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProcessCommandHandler : IRequestHandler<DeleteProcessCommand, Response<int>>
    {
        private readonly IProcessRepository _repository;
        public DeleteProcessCommandHandler(IProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Process Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
