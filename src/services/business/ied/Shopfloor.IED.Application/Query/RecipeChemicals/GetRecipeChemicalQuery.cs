using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeChemicals
{
    public class GetRecipeChemicalQuery : IRequest<Response<Domain.Entities.RecipeChemical>>
    {
        public int Id { get; set; }
    }

    public class GetRecipeChemicalQueryHandler : IRequestHandler<GetRecipeChemicalQuery, Response<Domain.Entities.RecipeChemical>>
    {
        private readonly IRecipeChemicalRepository _repository;

        public GetRecipeChemicalQueryHandler(IRecipeChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.RecipeChemical>> Handle(GetRecipeChemicalQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"RecipeChemical Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.RecipeChemical>(entity);
        }
    }
}