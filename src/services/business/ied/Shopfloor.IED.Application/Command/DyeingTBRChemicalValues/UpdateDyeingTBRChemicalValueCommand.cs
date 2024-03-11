using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicalValues
{
    public class UpdateDyeingTBRChemicalValueCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRChemicalId { get; set; }

        public int VersionIndex { get; set; }

        public decimal Value { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRChemicalValueCommandHandler : IRequestHandler<UpdateDyeingTBRChemicalValueCommand, Response<int>>
    {
        private readonly IDyeingTBRChemicalValueRepository _repository;

        public UpdateDyeingTBRChemicalValueCommandHandler(IDyeingTBRChemicalValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRChemicalValueCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DyeingTBRChemicalValue Not Found.");

            entity.Value = command.Value;
            entity.DyeingTBRChemicalId = command.DyeingTBRChemicalId;
            entity.VersionIndex = command.VersionIndex;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}