using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeCategories
{
    public class DeleteRecipeCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRecipeCategoryCommandHandler : IRequestHandler<DeleteRecipeCategoryCommand, Response<int>>
    {
        private readonly IRecipeCategoryRepository _repository;
        public DeleteRecipeCategoryCommandHandler(IRecipeCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRecipeCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"RecipeCategory Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
