using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeTasks
{
    public class GetRecipeTaskQuery : IRequest<Response<Domain.Entities.RecipeTask>>
    {
        public int Id { get; set; }
    }

    public class GetRecipeTaskQueryHandler : IRequestHandler<GetRecipeTaskQuery, Response<Domain.Entities.RecipeTask>>
    {
        private readonly IRecipeTaskRepository _repository;

        public GetRecipeTaskQueryHandler(IRecipeTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.RecipeTask>> Handle(GetRecipeTaskQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"RecipeTask Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.RecipeTask>(entity);
        }
    }
}