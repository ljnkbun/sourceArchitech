using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeTasks
{
    public class UpdateRecipeTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public int Minutes { get; set; }

        public decimal Temperature { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateRecipeTaskCommandHandler : IRequestHandler<UpdateRecipeTaskCommand, Response<int>>
    {
        private readonly IRecipeTaskRepository _repository;

        public UpdateRecipeTaskCommandHandler(IRecipeTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateRecipeTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"RecipeTask Not Found.");

            entity.RecipeId = command.RecipeId;
            entity.DyeingOpreation = command.DyeingOpreation;
            entity.MachineType = command.MachineType;
            entity.Minutes = command.Minutes;
            entity.Temperature = command.Temperature;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}