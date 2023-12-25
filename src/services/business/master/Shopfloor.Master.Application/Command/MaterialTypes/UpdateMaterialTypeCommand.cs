using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypes
{
    public class UpdateMaterialTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ICollection<UpdateCategoryMapMaterialTypeCommand> CategoryMapMaterialTypes { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateMaterialTypeCommandHandler : IRequestHandler<UpdateMaterialTypeCommand, Response<int>>
    {
        private readonly IMaterialTypeRepository _repository;
        public UpdateMaterialTypeCommandHandler(IMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetMaterialTypeByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"MaterialType Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CategoryId = command.CategoryId;
            entity.IsActive = command.IsActive;
            foreach (var item in entity.CategoryMapMaterialTypes)
            {
                item.CategoryId = command.CategoryId;
            }
            await _repository.UpdateMaterialTypeAsync(entity, entity.CategoryMapMaterialTypes);
            return new Response<int>(entity.Id);
        }
    }
}
