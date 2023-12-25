using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFeatureLibs
{
    public class GetSewingFeatureLibQuery : IRequest<Response<SewingFeatureLib>>
    {
        public int Id { get; set; }
    }
    public class GetSewingFeatureLibQueryHandler : IRequestHandler<GetSewingFeatureLibQuery, Response<SewingFeatureLib>>
    {
        private readonly ISewingFeatureLibRepository _repository;
        public GetSewingFeatureLibQueryHandler(ISewingFeatureLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingFeatureLib>> Handle(GetSewingFeatureLibQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingFeatureLibByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingFeatureLib Not Found (Id:{query.Id}).");
            return new Response<SewingFeatureLib>(entity);
        }
    }
}
