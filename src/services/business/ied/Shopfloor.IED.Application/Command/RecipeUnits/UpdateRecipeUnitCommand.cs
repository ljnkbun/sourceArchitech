using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeUnits
{
    public class UpdateRecipeUnitCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateRecipeUnitCommandHandler : IRequestHandler<UpdateRecipeUnitCommand, Response<int>>
    {
        private readonly IRecipeUnitRepository _repository;
        public UpdateRecipeUnitCommandHandler(IRecipeUnitRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRecipeUnitCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Recipe Unit Not Found.");

            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
