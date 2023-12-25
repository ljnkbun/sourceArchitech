using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicals
{
    public class UpdateDyeingTBRChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DyeingTBRTaskId { get; set; }
        public int ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRChemicalCommandHandler : IRequestHandler<UpdateDyeingTBRChemicalCommand, Response<int>>
    {
        private readonly IDyeingTBRChemicalRepository _repository;

        public UpdateDyeingTBRChemicalCommandHandler(IDyeingTBRChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRChemical Not Found.");

            entity.DyeingTBRTaskId = command.DyeingTBRTaskId;
            entity.ChemicalCode = command.ChemicalCode;
            entity.Unit = command.Unit;
            entity.ChemicalName = command.ChemicalName;
            entity.ChemicalId = command.ChemicalId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}