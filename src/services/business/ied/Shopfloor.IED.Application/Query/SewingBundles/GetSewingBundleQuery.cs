using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingBundles
{
    public class GetSewingBundleQuery : IRequest<Response<Domain.Entities.SewingBundle>>
    {
        public int Id { get; set; }
    }

    public class GetSewingBundleQueryHandler : IRequestHandler<GetSewingBundleQuery, Response<Domain.Entities.SewingBundle>>
    {
        private readonly ISewingBundleRepository _repository;

        public GetSewingBundleQueryHandler(ISewingBundleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.SewingBundle>> Handle(GetSewingBundleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingBundle Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.SewingBundle>(entity);
        }
    }
}