using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class DeleteRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Response<int>>
    {
        private readonly IRequestRepository _repository;
        public DeleteRequestCommandHandler(IRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Request Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
