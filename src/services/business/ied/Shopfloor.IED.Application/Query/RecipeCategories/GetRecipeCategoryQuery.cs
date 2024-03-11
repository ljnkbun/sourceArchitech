using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeCategories
{
    public class GetRecipeCategoryQuery : IRequest<Response<RecipeCategory>>
    {
        public int Id { get; set; }
    }
    public class GetRecipeCategoryQueryHandler : IRequestHandler<GetRecipeCategoryQuery, Response<RecipeCategory>>
    {
        private readonly IRecipeCategoryRepository _repository;
        public GetRecipeCategoryQueryHandler(IRecipeCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RecipeCategory>> Handle(GetRecipeCategoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"RecipeCategory Not Found (Id:{query.Id}).");
            return new Response<RecipeCategory>(entity);
        }
    }
}
