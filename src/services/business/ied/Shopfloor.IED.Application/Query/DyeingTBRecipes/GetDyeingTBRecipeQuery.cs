using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRecipes
{
    public class GetDyeingTBRecipeQuery : IRequest<Response<Domain.Entities.DyeingTBRecipe>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRecipeQueryHandler : IRequestHandler<GetDyeingTBRecipeQuery, Response<Domain.Entities.DyeingTBRecipe>>
    {
        private readonly IDyeingTBRecipeRepository _repository;

        public GetDyeingTBRecipeQueryHandler(IDyeingTBRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRecipe>> Handle(GetDyeingTBRecipeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBRecipe Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRecipe>(entity);
        }
    }
}