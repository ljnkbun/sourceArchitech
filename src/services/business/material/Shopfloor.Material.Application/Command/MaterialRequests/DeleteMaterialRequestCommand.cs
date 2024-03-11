using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class DeleteMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMaterialRequestCommandHandler : IRequestHandler<DeleteMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repository;

        public DeleteMaterialRequestCommandHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"MaterialRequest Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}