using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypes
{
    public class DeleteMaterialTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMaterialTypeCommandHandler : IRequestHandler<DeleteMaterialTypeCommand, Response<int>>
    {
        private readonly IMaterialTypeRepository _repository;
        public DeleteMaterialTypeCommandHandler(IMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"MaterialType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
