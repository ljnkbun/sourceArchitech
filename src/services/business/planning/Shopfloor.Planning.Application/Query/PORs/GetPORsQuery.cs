using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.PORs;
using Shopfloor.Planning.Application.Parameters.PORs;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.PORs
{
    public class GetPORsQuery : IRequest<PagedResponse<IReadOnlyList<PORModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsRemaining { get; set; }
        public int? WfxOCId { get; set; }
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? WfxPORId { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public int? DivisionId { get; set; }
        public int? WfxArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public int? BOMId { get; set; }
        public string BOMNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainingQuantity { get; set; }
        public PorType? TypePOR { get; set; }
        public bool? IsAllocated { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessId { get; set; }
        public string UOM { get; set; }
        public int? OrderId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public string JobOrderNo { get; set; }
    }
    public class GetWfxPORsQueryHandler : IRequestHandler<GetPORsQuery, PagedResponse<IReadOnlyList<PORModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPORRepository _response;
        public GetWfxPORsQueryHandler(IMapper mapper
            , IPORRepository response)
        {
            _mapper = mapper;
            _response = response;
        }

        public async Task<PagedResponse<IReadOnlyList<PORModel>>> Handle(GetPORsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PORParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            return await _response.GetModelPagedReponseIsRemainingAsync<PORParameter, PORModel>(validFilter, validFilter.IsRemaining);
        }
    }
}