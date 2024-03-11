using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxImportSyncs;
using Shopfloor.Barcode.Application.Parameters.WfxImportSyncs;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ImportArticles
{
    public class GetWfxImportSyncsQuery : IRequest<Response<IReadOnlyList<WfxImportSyncModel>>>
    {
        public List<WfxImportSyncParameter> Parameters { get; set; }
    }

    public class GetWfxImportSyncEntitiesQueryHandler : IRequestHandler<GetWfxImportSyncsQuery, Response<IReadOnlyList<WfxImportSyncModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportArticleRepository _repository;

        public GetWfxImportSyncEntitiesQueryHandler(IMapper mapper,
            IImportArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<IReadOnlyList<WfxImportSyncModel>>> Handle(GetWfxImportSyncsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetImportSyncAsync<WfxImportSyncParameter, WfxImportSyncModel>(request.Parameters);
            foreach (var item in response.Data)
            {
                item.OrderType = request.Parameters.Select(x => x.OrderType).FirstOrDefault();
            }
            return response;
        }
    }
}
