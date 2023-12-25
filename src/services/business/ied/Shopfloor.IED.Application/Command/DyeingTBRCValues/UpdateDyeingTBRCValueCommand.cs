using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRCValues
{
    public class UpdateDyeingTBRCValueCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRChemicalId { get; set; }

        public int DyeingTBRVersionId { get; set; }

        public decimal Value { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRCValueCommandHandler : IRequestHandler<UpdateDyeingTBRCValueCommand, Response<int>>
    {
        private readonly IDyeingTBRCValueRepository _repository;

        public UpdateDyeingTBRCValueCommandHandler(IDyeingTBRCValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRCValueCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRCValue Not Found.");

            entity.Value = command.Value;
            entity.DyeingTBRChemicalId = command.DyeingTBRChemicalId;
            entity.DyeingTBRVersionId = command.DyeingTBRVersionId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}