using AutoMapper;
using MediatR;
using Shopfloor.Planning.Application.Models.MergeSplitPORs;
using Shopfloor.Planning.Application.Parameters.MergeSplitPORs;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.MergeSplitPORs
{
    public class GetMergeSplitPORsQuery : IRequest<PagedResponse<IReadOnlyList<MergeSplitPORModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FromPORId { get; set; }
		public int? ToPORId { get; set; }
		public decimal Quantity { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"MergeSplitPOR";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMergeSplitPORsQueryHandler : IRequestHandler<GetMergeSplitPORsQuery, PagedResponse<IReadOnlyList<MergeSplitPORModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMergeSplitPORRepository _repository;
        public GetMergeSplitPORsQueryHandler(IMapper mapper,
            IMergeSplitPORRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MergeSplitPORModel>>> Handle(GetMergeSplitPORsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MergeSplitPORParameter>(request);
            return await _repository.GetModelPagedReponseAsync<MergeSplitPORParameter, MergeSplitPORModel>(validFilter);
        }
    }
}
