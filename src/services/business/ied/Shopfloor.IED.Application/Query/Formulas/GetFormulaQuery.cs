using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Formulas
{
    public class GetFormulaQuery : IRequest<Response<Formula>>
    {
        public int Id { get; set; }
    }
    public class GetFormulaQueryHandler : IRequestHandler<GetFormulaQuery, Response<Formula>>
    {
        private readonly IFormulaRepository _repository;
        public GetFormulaQueryHandler(IFormulaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Formula>> Handle(GetFormulaQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Formula Not Found (Id:{query.Id}).");
            return new Response<Formula>(entity);
        }
    }
}
