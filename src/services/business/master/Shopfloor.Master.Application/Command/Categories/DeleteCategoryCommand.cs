using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Categories
{
    public class DeleteCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Category Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
