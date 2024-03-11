using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingProcessChemicals
{
    public class UpdateDyeingProcessChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingRoutingId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategoryName { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingProcessChemicalCommandHandler : IRequestHandler<UpdateDyeingProcessChemicalCommand, Response<int>>
    {
        private readonly IDyeingProcessChemicalRepository _repository;

        public UpdateDyeingProcessChemicalCommandHandler(IDyeingProcessChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingProcessChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DyeingProcessChemical Not Found.");

            entity.DyeingRoutingId = command.DyeingRoutingId;
            entity.ChemicalCode = command.ChemicalCode;
            entity.ChemicalName = command.ChemicalName;
            entity.IsActive = command.IsActive;
            entity.SubCategoryCode = command.SubCategoryCode;
            entity.SubCategoryName = command.SubCategoryName;
            entity.Quantity = command.Quantity;
            entity.Unit = command.Unit;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}