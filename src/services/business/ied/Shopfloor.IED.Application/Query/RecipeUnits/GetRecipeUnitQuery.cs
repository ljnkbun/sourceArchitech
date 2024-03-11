using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeUnits
{
    public class GetRecipeUnitQuery : IRequest<Response<RecipeUnit>>
    {
        public int Id { get; set; }
    }

    public class GetRecipeUnitQueryHandler : IRequestHandler<GetRecipeUnitQuery, Response<RecipeUnit>>
    {
        private readonly IRecipeUnitRepository _repository;

        public GetRecipeUnitQueryHandler(IRecipeUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<RecipeUnit>> Handle(GetRecipeUnitQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Recipe Unit Not Found (Id:{query.Id}).");
            return new Response<RecipeUnit>(entity);
        }
    }
}