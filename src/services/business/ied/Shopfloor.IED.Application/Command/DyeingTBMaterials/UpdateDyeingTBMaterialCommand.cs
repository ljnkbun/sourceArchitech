using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterials
{
    public class UpdateDyeingTBMaterialCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRequestId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string FabricStyleRef { get; set; }

        public string MaterialType { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UpdateDyeingTBMaterialColorCommand> DyeingTBMaterialColors { get; set; }
    }

    public class UpdateDyeingTBMaterialCommandHandler : IRequestHandler<UpdateDyeingTBMaterialCommand, Response<int>>
    {
        private readonly IDyeingTBMaterialRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingTBMaterialCommandHandler(IDyeingTBMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBMaterialCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);

            if (entity == null) return new($"DyeingTBMaterial Not Found.");

            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.WFXArticleId = command.WFXArticleId;
            entity.DyeingTBRequestId = command.DyeingTBRequestId;
            entity.MaterialType = command.MaterialType;
            entity.FabricContent = command.FabricContent;
            entity.Lights = command.Lights;
            entity.FabricStyleRef = command.FabricStyleRef;
            entity.IsActive = command.IsActive;
            var dbDyeingTBMaterialColors = entity.DyeingTBMaterialColors;
            entity.DyeingTBMaterialColors = null;

            #region DyeingTBMaterialColor

            var dbDyeingTBMaterialColorModifieds = dbDyeingTBMaterialColors.Where(x => command.DyeingTBMaterialColors.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.DyeingTBMaterialColors.First(c => c.Id == x.Id), x));

            var newDyeingTBMaterialColorAddeds = command.DyeingTBMaterialColors.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<DyeingTBMaterialColor>(x));

            var dbDyeingTBMaterialColorDeletes =
                dbDyeingTBMaterialColors.Where(x => dbDyeingTBMaterialColorModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBMaterialColor

            await _repository.UpdateDyeingTBMaterialAsync(entity, new BaseUpdateEntity<DyeingTBMaterialColor>
            {
                LstDataAdd = newDyeingTBMaterialColorAddeds,
                LstDataDelete = dbDyeingTBMaterialColorDeletes,
                LstDataUpdate = dbDyeingTBMaterialColorModifieds
            });
            return new Response<int>(entity.Id);
        }
    }
}