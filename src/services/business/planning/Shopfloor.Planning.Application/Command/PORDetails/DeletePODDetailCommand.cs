using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORDetails
{
    public class DeletePODDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePODDetailCommandHandler : IRequestHandler<DeletePODDetailCommand, Response<int>>
    {
        private readonly IPORRepository _repository;
        public DeletePODDetailCommandHandler(IPORRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeletePODDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"PORDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }

}
