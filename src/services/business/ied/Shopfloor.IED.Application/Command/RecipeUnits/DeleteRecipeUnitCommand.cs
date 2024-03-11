using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeUnits
{
    public class DeleteRecipeUnitCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRecipeUnitCommandHandler : IRequestHandler<DeleteRecipeUnitCommand, Response<int>>
    {
        private readonly IRecipeUnitRepository _repository;
        public DeleteRecipeUnitCommandHandler(IRecipeUnitRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRecipeUnitCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Recipe Unit Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
