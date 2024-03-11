using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingIEDs;
using Shopfloor.IED.Application.Parameters.KnittingIEDs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingIEDs
{
    public class GetKnittingIEDsQuery : IRequest<PagedResponse<IReadOnlyList<KnittingIEDModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string RequestNo { get; set; }
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Buyer { get; set; }
        public string Remark { get; set; }
        public Status? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetKnittingIEDsQueryHandler : IRequestHandler<GetKnittingIEDsQuery, PagedResponse<IReadOnlyList<KnittingIEDModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingIEDRepository _repository;
        public GetKnittingIEDsQueryHandler(IMapper mapper,
            IKnittingIEDRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingIEDModel>>> Handle(GetKnittingIEDsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingIEDParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingIEDParameter, KnittingIEDModel>(validFilter);
        }
    }
}
