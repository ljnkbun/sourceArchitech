using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterialColors
{
    public class GetDyeingTBMaterialColorWithParentQuery : IRequest<Response<Domain.Entities.DyeingTBMaterialColor>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBMaterialColorWithParentQueryHandler : IRequestHandler<GetDyeingTBMaterialColorWithParentQuery, Response<Domain.Entities.DyeingTBMaterialColor>>
    {
        private readonly IDyeingTBMaterialColorRepository _repository;

        public GetDyeingTBMaterialColorWithParentQueryHandler(IDyeingTBMaterialColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBMaterialColor>> Handle(GetDyeingTBMaterialColorWithParentQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithParentByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBMaterialColor Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBMaterialColor>(entity);
        }
    }
}