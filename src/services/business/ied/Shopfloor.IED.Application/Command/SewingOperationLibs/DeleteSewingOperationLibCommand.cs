using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibs
{
    public class DeleteSewingOperationLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingOperationLibCommandHandler : IRequestHandler<DeleteSewingOperationLibCommand, Response<int>>
    {
        private readonly ISewingOperationLibRepository _repository;
        public DeleteSewingOperationLibCommandHandler(ISewingOperationLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingOperationLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingOperationLib Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
