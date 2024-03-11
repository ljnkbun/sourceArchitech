using MediatR;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.CapacityColors
{
    public class DeleteCapacityColorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCapacityColorCommandHandler : IRequestHandler<DeleteCapacityColorCommand, Response<int>>
    {
        private readonly ICapacityColorRepository _repository;
        public DeleteCapacityColorCommandHandler(ICapacityColorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCapacityColorCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CapacityColor Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
