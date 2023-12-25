using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubCategories
{
    public class DeleteSubCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, Response<int>>
    {
        private readonly ISubCategoryRepository _repository;
        public DeleteSubCategoryCommandHandler(ISubCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SubCategory Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
