using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeChemicals
{
    public class DeleteRecipeChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRecipeChemicalCommandHandler : IRequestHandler<DeleteRecipeChemicalCommand, Response<int>>
    {
        private readonly IRecipeChemicalRepository _repository;

        public DeleteRecipeChemicalCommandHandler(IRecipeChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteRecipeChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"RecipeChemical Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}