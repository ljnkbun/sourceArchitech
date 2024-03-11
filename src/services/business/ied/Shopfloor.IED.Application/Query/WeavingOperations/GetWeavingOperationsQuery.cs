using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingOperations;
using Shopfloor.IED.Application.Parameters.WeavingOperations;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingOperations
{
    public class GetWeavingOperationsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingOperationModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingRoutingId { get; set; }
        public int? LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetWeavingOperationsQueryHandler : IRequestHandler<GetWeavingOperationsQuery, PagedResponse<IReadOnlyList<WeavingOperationModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingOperationRepository _repository;

        public GetWeavingOperationsQueryHandler(IMapper mapper,
            IWeavingOperationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingOperationModel>>> Handle(GetWeavingOperationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingOperationParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingOperationParameter, WeavingOperationModel>(validFilter);
        }
    }
}