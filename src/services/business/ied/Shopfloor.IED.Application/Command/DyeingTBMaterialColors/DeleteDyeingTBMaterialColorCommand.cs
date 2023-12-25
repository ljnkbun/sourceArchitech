using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterialColors
{
    public class DeleteDyeingTBMaterialColorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBMaterialColorCommandHandler : IRequestHandler<DeleteDyeingTBMaterialColorCommand, Response<int>>
    {
        private readonly IDyeingTBMaterialColorRepository _repository;

        public DeleteDyeingTBMaterialColorCommandHandler(IDyeingTBMaterialColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBMaterialColorCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBMaterialColor Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}