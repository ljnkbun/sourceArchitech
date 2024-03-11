using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicalValues
{
    public class DeleteDyeingTBRChemicalValueCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRChemicalValueCommandHandler : IRequestHandler<DeleteDyeingTBRChemicalValueCommand, Response<int>>
    {
        private readonly IDyeingTBRChemicalValueRepository _repository;

        public DeleteDyeingTBRChemicalValueCommandHandler(IDyeingTBRChemicalValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRChemicalValueCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRChemicalValue Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}