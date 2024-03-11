using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CategoryMapMaterialTypes
{
    public class UpdateCategoryMapMaterialTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateCategoryMapMaterialTypeCommandHandler : IRequestHandler<UpdateCategoryMapMaterialTypeCommand, Response<int>>
    {
        private readonly ICategoryMapMaterialTypeRepository _repository;
        public UpdateCategoryMapMaterialTypeCommandHandler(ICategoryMapMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCategoryMapMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"CategoryMapMaterialType Not Found.");

            entity.CategoryId = command.CategoryId;
            entity.MaterialTypeId = command.MaterialTypeId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
