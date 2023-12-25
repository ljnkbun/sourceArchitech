using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeTasks
{
    public class DeleteRecipeTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRecipeTaskCommandHandler : IRequestHandler<DeleteRecipeTaskCommand, Response<int>>
    {
        private readonly IRecipeTaskRepository _repository;

        public DeleteRecipeTaskCommandHandler(IRecipeTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteRecipeTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"RecipeTask Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}