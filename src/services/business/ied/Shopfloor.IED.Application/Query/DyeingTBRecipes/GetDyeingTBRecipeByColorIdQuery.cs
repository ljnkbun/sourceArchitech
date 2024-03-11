using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRecipes
{
    public class GetDyeingTBRecipeByColorIdQuery : IRequest<Response<Domain.Entities.DyeingTBRecipe>>
    {
        public int DyeingTBMaterialColorId { get; set; }
    }

    public class GetDyeingTBRecipeColorQueryHandler : IRequestHandler<GetDyeingTBRecipeByColorIdQuery, Response<Domain.Entities.DyeingTBRecipe>>
    {
        private readonly IDyeingTBRecipeRepository _repository;

        public GetDyeingTBRecipeColorQueryHandler(IDyeingTBRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRecipe>> Handle(GetDyeingTBRecipeByColorIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByColorIdAsync(query.DyeingTBMaterialColorId);
            if (entity == null) return new($"DyeingTBRecipe Not Found (DyeingTBMaterialColorId:{query.DyeingTBMaterialColorId}).");
            return new Response<Domain.Entities.DyeingTBRecipe>(entity);
        }
    }
}