using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Recipes
{
    public class SoftDeleteRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SoftDeleteRecipeCommandHandler : IRequestHandler<SoftDeleteRecipeCommand, Response<int>>
    {
        private readonly IRecipeRepository _repository;

        public SoftDeleteRecipeCommandHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SoftDeleteRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Recipe Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}