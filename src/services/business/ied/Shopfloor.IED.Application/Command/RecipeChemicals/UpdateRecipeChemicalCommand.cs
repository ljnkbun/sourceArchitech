using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeChemicals
{
    public class UpdateRecipeChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string ChemicalSubcategory { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateRecipeChemicalCommandHandler : IRequestHandler<UpdateRecipeChemicalCommand, Response<int>>
    {
        private readonly IRecipeChemicalRepository _repository;

        public UpdateRecipeChemicalCommandHandler(IRecipeChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateRecipeChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"RecipeChemical Not Found.");

            entity.RecipeTaskId = command.RecipeTaskId;
            entity.ChemicalCode = command.ChemicalCode;
            entity.ChemicalName = command.ChemicalName;
            entity.ChemicalSubcategory = command.ChemicalSubcategory;
            entity.Unit = command.Unit;
            entity.Value = command.Value;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}