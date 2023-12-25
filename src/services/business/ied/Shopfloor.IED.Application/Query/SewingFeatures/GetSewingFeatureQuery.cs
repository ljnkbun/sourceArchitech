using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFeatures
{
    public class GetSewingFeatureQuery : IRequest<Response<SewingFeature>>
    {
        public int Id { get; set; }
    }
    public class GetSewingFeatureQueryHandler : IRequestHandler<GetSewingFeatureQuery, Response<SewingFeature>>
    {
        private readonly ISewingFeatureRepository _repository;
        public GetSewingFeatureQueryHandler(ISewingFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingFeature>> Handle(GetSewingFeatureQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingFeatureByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingFeature Not Found (Id:{query.Id}).");
            return new Response<SewingFeature>(entity);
        }
    }
}
