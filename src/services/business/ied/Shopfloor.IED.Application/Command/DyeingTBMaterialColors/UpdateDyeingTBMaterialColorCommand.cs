using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterialColors
{
    public class UpdateDyeingTBMaterialColorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public TBMaterialColorStatus Status { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBMaterialColorCommandHandler : IRequestHandler<UpdateDyeingTBMaterialColorCommand, Response<int>>
    {
        private readonly IDyeingTBMaterialColorRepository _repository;

        public UpdateDyeingTBMaterialColorCommandHandler(IDyeingTBMaterialColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBMaterialColorCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBMaterialColor Not Found.");

            entity.Color = command.Color;
            entity.Pantone = command.Pantone;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;
            entity.DyeingTBMaterialId = command.DyeingTBMaterialId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}