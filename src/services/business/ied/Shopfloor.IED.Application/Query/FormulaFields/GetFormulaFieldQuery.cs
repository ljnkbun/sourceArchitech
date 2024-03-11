using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.FormulaFields
{
    public class GetFormulaFieldQuery : IRequest<Response<FormulaField>>
    {
        public int Id { get; set; }
    }
    public class GetFormulaFieldQueryHandler : IRequestHandler<GetFormulaFieldQuery, Response<FormulaField>>
    {
        private readonly IFormulaFieldRepository _repository;
        public GetFormulaFieldQueryHandler(IFormulaFieldRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FormulaField>> Handle(GetFormulaFieldQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"FormulaField Not Found (Id:{query.Id}).");
            return new Response<FormulaField>(entity);
        }
    }
}
