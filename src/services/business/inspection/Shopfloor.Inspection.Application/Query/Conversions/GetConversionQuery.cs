using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.Conversions
{
    public class GetConversionQuery : IRequest<Response<Conversion>>
    {
        public int Id { get; set; }
    }
    public class GetConversionQueryHandler : IRequestHandler<GetConversionQuery, Response<Conversion>>
    {
        private readonly IConversionRepository _repository;
        public GetConversionQueryHandler(IConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Conversion>> Handle(GetConversionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Conversions Not Found (Id:{query.Id}).");
            return new Response<Conversion>(entity);
        }
    }
}
