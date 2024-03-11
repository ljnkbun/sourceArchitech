using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterialColors
{
    public class GetDyeingTBMaterialColorQuery : IRequest<Response<Domain.Entities.DyeingTBMaterialColor>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBMaterialColorQueryHandler : IRequestHandler<GetDyeingTBMaterialColorQuery, Response<Domain.Entities.DyeingTBMaterialColor>>
    {
        private readonly IDyeingTBMaterialColorRepository _repository;

        public GetDyeingTBMaterialColorQueryHandler(IDyeingTBMaterialColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBMaterialColor>> Handle(GetDyeingTBMaterialColorQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBMaterialColor Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBMaterialColor>(entity);
        }
    }
}