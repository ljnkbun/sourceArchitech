using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Recipes
{
    public class GetRecipeQuery : IRequest<Response<Domain.Entities.Recipe>>
    {
        public int Id { get; set; }
    }

    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, Response<Domain.Entities.Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipeQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.Recipe>> Handle(GetRecipeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Recipe Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.Recipe>(entity);
        }
    }
}