using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCRequests
{
    public class DeleteQCRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCRequestCommandHandler : IRequestHandler<DeleteQCRequestCommand, Response<int>>
    {
        private readonly IQCRequestRepository _repository;
        public DeleteQCRequestCommandHandler(IQCRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"QCRequest Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
