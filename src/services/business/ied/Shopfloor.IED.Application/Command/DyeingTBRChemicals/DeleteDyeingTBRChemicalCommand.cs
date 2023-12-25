using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicals
{
    public class DeleteDyeingTBRChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRChemicalCommandHandler : IRequestHandler<DeleteDyeingTBRChemicalCommand, Response<int>>
    {
        private readonly IDyeingTBRChemicalRepository _repository;

        public DeleteDyeingTBRChemicalCommandHandler(IDyeingTBRChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRChemical Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}