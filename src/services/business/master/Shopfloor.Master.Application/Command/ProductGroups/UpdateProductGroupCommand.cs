using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class UpdateProductGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public ICollection<UpdateMaterialTypeMapProductGroupCommand> MaterialTypeMapProductGroups { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, Response<int>>
    {
        private readonly IProductGroupRepository _repository;

        public UpdateProductGroupCommandHandler(IProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProductGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProductGroupByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"ProductGroup Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CategoryId = command.CategoryId;
            entity.MaterialTypeId = command.MaterialTypeId;
            entity.IsActive = command.IsActive;
            foreach (var item in entity.MaterialTypeMapProductGroups)
            {
                item.MaterialTypeId = command.MaterialTypeId;
            }
            await _repository.UpdateProductGroupAsync(entity, entity.MaterialTypeMapProductGroups);
            return new Response<int>(entity.Id);
        }
    }
}
