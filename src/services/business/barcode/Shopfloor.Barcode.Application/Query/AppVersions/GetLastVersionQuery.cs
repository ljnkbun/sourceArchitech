using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.AppVersions
{
    public class GetLastVersionQuery : IRequest<Response<AppVersion>>
    {
    }

    public class GetLastVersionQueryHandler : IRequestHandler<GetLastVersionQuery, Response<AppVersion>>
    {
        private readonly IAppVersionRepository _repository;

        public GetLastVersionQueryHandler(IAppVersionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<AppVersion>> Handle(GetLastVersionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetLastVersion();
            if (entity == null) return new($"Last Version Not Found.");
            return new Response<AppVersion>(entity);
        }
    }
}