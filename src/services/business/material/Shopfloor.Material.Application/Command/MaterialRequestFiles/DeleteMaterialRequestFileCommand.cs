using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequestFiles
{
    public class DeleteMaterialRequestFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMaterialRequestFileCommandHandler : IRequestHandler<DeleteMaterialRequestFileCommand, Response<int>>
    {
        private readonly IMaterialRequestFileRepository _repository;

        public DeleteMaterialRequestFileCommandHandler(IMaterialRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteMaterialRequestFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"MaterialRequestFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}