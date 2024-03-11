using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups
{
    public class UpdateMaterialTypeMapProductGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public int MaterialTypeId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateMaterialTypeMapProductGroupCommandHandler : IRequestHandler<UpdateMaterialTypeMapProductGroupCommand, Response<int>>
    {
        private readonly IMaterialTypeMapProductGroupRepository _repository;
        public UpdateMaterialTypeMapProductGroupCommandHandler(IMaterialTypeMapProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateMaterialTypeMapProductGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"MaterialTypeMapProductGroup Not Found.");

            entity.ProductGroupId = command.ProductGroupId;
            entity.MaterialTypeId = command.MaterialTypeId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
