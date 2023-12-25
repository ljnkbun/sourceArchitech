using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterials
{
    public class GetDyeingTBMaterialQuery : IRequest<Response<Domain.Entities.DyeingTBMaterial>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBMaterialQueryHandler : IRequestHandler<GetDyeingTBMaterialQuery, Response<Domain.Entities.DyeingTBMaterial>>
    {
        private readonly IDyeingTBMaterialRepository _repository;

        public GetDyeingTBMaterialQueryHandler(IDyeingTBMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBMaterial>> Handle(GetDyeingTBMaterialQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DyeingTBMaterial Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBMaterial>(entity);
        }
    }
}