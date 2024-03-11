using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterials
{
    public class CreateDyeingTBMaterialCommand : IRequest<Response<int>>
    {
        public int DyeingTBRequestId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialType { get; set; }

        public string FabricStyleRef { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

        public ICollection<CreateDyeingTBMaterialColorCommand> DyeingTBMaterialColors { get; set; }
    }

    public class CreateDyeingTBMaterialCommandHandler : IRequestHandler<CreateDyeingTBMaterialCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBMaterialRepository _repository;

        public CreateDyeingTBMaterialCommandHandler(IMapper mapper,
            IDyeingTBMaterialRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBMaterial>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}