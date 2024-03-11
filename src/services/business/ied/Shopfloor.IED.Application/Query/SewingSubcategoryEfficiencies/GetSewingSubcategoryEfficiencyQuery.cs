using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencys
{
    public class GetSewingSubcategoryEfficiencyQuery : IRequest<Response<Domain.Entities.SewingSubcategoryEfficiency>>
    {
        public int Id { get; set; }
    }

    public class GetSewingSubcategoryEfficiencyQueryHandler : IRequestHandler<GetSewingSubcategoryEfficiencyQuery, Response<Domain.Entities.SewingSubcategoryEfficiency>>
    {
        private readonly ISewingSubcategoryEfficiencyRepository _repository;

        public GetSewingSubcategoryEfficiencyQueryHandler(ISewingSubcategoryEfficiencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.SewingSubcategoryEfficiency>> Handle(GetSewingSubcategoryEfficiencyQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingSubcategoryEfficiency Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.SewingSubcategoryEfficiency>(entity);
        }
    }
}