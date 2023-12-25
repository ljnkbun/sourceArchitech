using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterials
{
    public class UpdateDyeingTBMaterialCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRequestId { get; set; }

        public string ArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialType { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBMaterialCommandHandler : IRequestHandler<UpdateDyeingTBMaterialCommand, Response<int>>
    {
        private readonly IDyeingTBMaterialRepository _repository;

        public UpdateDyeingTBMaterialCommandHandler(IDyeingTBMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBMaterialCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBMaterial Not Found.");

            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.ArticleId = command.ArticleId;
            entity.DyeingTBRequestId = command.DyeingTBRequestId;
            entity.MaterialType = command.MaterialType;
            entity.FabricContent = command.FabricContent;
            entity.Lights = command.Lights;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}