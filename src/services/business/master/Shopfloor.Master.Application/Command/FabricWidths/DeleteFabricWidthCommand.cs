using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FabricWidths
{
    public class DeleteFabricWidthCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFabricWidthCommandHandler : IRequestHandler<DeleteFabricWidthCommand, Response<int>>
    {
        private readonly IFabricWidthRepository _repository;
        public DeleteFabricWidthCommandHandler(IFabricWidthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFabricWidthCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FabricWidth Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
