using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterials
{
    public class DeleteDyeingTBMaterialCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBMaterialCommandHandler : IRequestHandler<DeleteDyeingTBMaterialCommand, Response<int>>
    {
        private readonly IDyeingTBMaterialRepository _repository;

        public DeleteDyeingTBMaterialCommandHandler(IDyeingTBMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBMaterialCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBMaterial Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}