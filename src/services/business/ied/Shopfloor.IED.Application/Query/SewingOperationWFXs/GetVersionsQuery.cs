using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationWFXs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationWFXs
{
    public class GetVersionsQuery : IRequest<Response<List<VersionModel>>>
    {
        public int SewingOperationWFXId { get; set; }
    }
    public class GetVersionsQueryHandler : IRequestHandler<GetVersionsQuery, Response<List<VersionModel>>>
    {
        private readonly ISewingOperationWFXRepository _repository;
        private readonly IMapper _mapper;

        public GetVersionsQueryHandler(ISewingOperationWFXRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<VersionModel>>> Handle(GetVersionsQuery query, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetVersionsAsync(query.SewingOperationWFXId);
            if (entities == null) throw new ApiException($"Version Not Found (SewingOperationWFXId:{query.SewingOperationWFXId}).");

            var versions = _mapper.Map<List<VersionModel>>(entities);
            return new Response<List<VersionModel>>(versions);
        }
    }
}
