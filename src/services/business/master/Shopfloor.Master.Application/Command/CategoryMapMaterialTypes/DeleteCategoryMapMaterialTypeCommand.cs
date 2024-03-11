using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CategoryMapMaterialTypes
{
    public class DeleteCategoryMapMaterialTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCategoryMapMaterialTypeCommandHandler : IRequestHandler<DeleteCategoryMapMaterialTypeCommand, Response<int>>
    {
        private readonly ICategoryMapMaterialTypeRepository _repository;
        public DeleteCategoryMapMaterialTypeCommandHandler(ICategoryMapMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCategoryMapMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CategoryMapMaterialType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
