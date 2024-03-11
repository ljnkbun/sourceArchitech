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

        public int DyeingProcessId { get; set; }

        public string DyeingProcessName { get; set; }

        public decimal Ratio { get; set; }

        public int DyeingOperationId { get; set; }

        public string DyeingOperationName { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Time { get; set; }

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

            if (entity == null) return new($"RecipeTask Not Found.");

            entity.RecipeId = command.RecipeId;
            entity.DyeingOperationId = command.DyeingOperationId;
            entity.DyeingOperationName = command.DyeingOperationName;
            entity.DyeingProcessName = command.DyeingProcessName;
            entity.DyeingProcessId = command.DyeingProcessId;
            entity.MachineName = command.MachineName;
            entity.MachineCode = command.MachineCode;
            entity.DyeingOperationCode = command.DyeingOperationCode;
            entity.DyeingProcessCode = command.DyeingProcessCode;
            entity.Time = command.Time;
            entity.Temperature = command.Temperature;
            entity.IsActive = command.IsActive;
            entity.Ratio = command.Ratio;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}