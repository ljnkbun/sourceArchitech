using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Recipes
{
    public class DeleteRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Response<int>>
    {
        private readonly IRecipeRepository _repository;

        public DeleteRecipeCommandHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Recipe Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}