using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups
{
    public class DeleteMaterialTypeMapProductGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMaterialTypeMapProductGroupCommandHandler : IRequestHandler<DeleteMaterialTypeMapProductGroupCommand, Response<int>>
    {
        private readonly IMaterialTypeMapProductGroupRepository _repository;
        public DeleteMaterialTypeMapProductGroupCommandHandler(IMaterialTypeMapProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMaterialTypeMapProductGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"MaterialTypeMapProductGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
