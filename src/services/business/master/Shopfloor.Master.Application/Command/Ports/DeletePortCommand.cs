using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Ports
{
    public class DeletePortCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePortCommandHandler : IRequestHandler<DeletePortCommand, Response<int>>
    {
        private readonly IPortRepository _repository;
        public DeletePortCommandHandler(IPortRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePortCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Port Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
