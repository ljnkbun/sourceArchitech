using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FiberTypes
{
    public class DeleteFiberTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFiberTypeCommandHandler : IRequestHandler<DeleteFiberTypeCommand, Response<int>>
    {
        private readonly IFiberTypeRepository _repository;
        public DeleteFiberTypeCommandHandler(IFiberTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFiberTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FiberType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
