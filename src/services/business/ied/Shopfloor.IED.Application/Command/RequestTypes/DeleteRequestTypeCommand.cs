using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestTypes
{
    public class DeleteRequestTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestTypeCommandHandler : IRequestHandler<DeleteRequestTypeCommand, Response<int>>
    {
        private readonly IRequestTypeRepository _repository;
        public DeleteRequestTypeCommandHandler(IRequestTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"RequestType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
