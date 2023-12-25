using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Recipes
{
    public class UpdateRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRequestId { get; set; }

        public int DyeingTBRVersionId { get; set; }

        public DateTime JobDate { get; set; }

        public string TCFNO { get; set; }

        public string Style { get; set; }

        public string FabricCode { get; set; }

        public string FabricName { get; set; }

        public string Color { get; set; }

        public string LotNo { get; set; }

        public string RollKg { get; set; }

        public string Speed { get; set; }

        public string NozzleA { get; set; }

        public string NozzleB { get; set; }

        public string Method { get; set; }

        public string LAB { get; set; }

        public string InCharge { get; set; }

        public string Manager { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Response<int>>
    {
        private readonly IRecipeRepository _repository;

        public UpdateRecipeCommandHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"Recipe Not Found.");

            entity.DyeingTBRequestId = command.DyeingTBRequestId;
            entity.DyeingTBRVersionId = command.DyeingTBRVersionId;
            entity.JobDate = command.JobDate;
            entity.DyeingTBRequestId = command.DyeingTBRequestId;
            entity.TCFNO = command.TCFNO;
            entity.Style = command.Style;
            entity.FabricCode = command.FabricCode;
            entity.FabricName = command.FabricName;
            entity.Color = command.Color;
            entity.LotNo = command.LotNo;
            entity.RollKg = command.RollKg;
            entity.Speed = command.Speed;
            entity.NozzleA = command.NozzleA;
            entity.NozzleB = command.NozzleB;
            entity.Method = command.Method;
            entity.LAB = command.LAB;
            entity.InCharge = command.InCharge;
            entity.Manager = command.Manager;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}