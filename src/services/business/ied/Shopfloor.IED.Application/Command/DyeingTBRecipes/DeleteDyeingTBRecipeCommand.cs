using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRecipes
{
    public class DeleteDyeingTBRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRecipeCommandHandler : IRequestHandler<DeleteDyeingTBRecipeCommand, Response<int>>
    {
        private readonly IDyeingTBRecipeRepository _repository;

        public DeleteDyeingTBRecipeCommandHandler(IDyeingTBRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRecipe Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}