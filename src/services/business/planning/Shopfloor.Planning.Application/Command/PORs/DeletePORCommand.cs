using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORs
{
    public class DeletePORCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePORCommandHandler : IRequestHandler<DeletePORCommand, Response<int>>
    {
        private readonly IPORRepository _repository;
        public DeletePORCommandHandler(IPORRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeletePORCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"POR Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
