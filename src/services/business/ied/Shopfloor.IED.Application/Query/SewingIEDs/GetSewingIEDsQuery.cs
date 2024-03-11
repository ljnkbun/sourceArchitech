using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingIEDs;
using Shopfloor.IED.Application.Parameters.SewingIEDs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingIEDs
{
    public class GetSewingIEDsQuery : IRequest<PagedResponse<IReadOnlyList<SewingIEDModel>>>
    {
        public string RequestNo { get; set; }
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Buyer { get; set; }
        public string StyleRef { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public decimal? SMV { get; set; }
        public decimal? AllowedTime { get; set; }
        public decimal? FactoryTime { get; set; }
        public decimal? LabourCostOp { get; set; }
        public decimal? LabourCostFactory { get; set; }
        public decimal? FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal? LabourCostFactoryIncludingOverhead { get; set; }
        public string Comment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public string AnalysisUser { get; set; }
        public Status? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? Deleted { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetSewingIEDsQueryHandler : IRequestHandler<GetSewingIEDsQuery, PagedResponse<IReadOnlyList<SewingIEDModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingIEDRepository _repository;
        public GetSewingIEDsQueryHandler(IMapper mapper,
            ISewingIEDRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingIEDModel>>> Handle(GetSewingIEDsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingIEDParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingIEDParameter, SewingIEDModel>(validFilter);
        }
    }
}
