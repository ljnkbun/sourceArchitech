using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.MergeSplitPorDetails;
using Shopfloor.Planning.Application.Parameters.MergeSplitPorDetails;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.MergeSplitPORs
{
    public class GetMergeSplitPorDetailsQuery : IRequest<PagedResponse<IReadOnlyList<MergeSplitPorDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FromPorDetailId { get; set; }
        public int? ToPorDetailId { get; set; }
        public decimal Quantity { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"MergeSplitPORDetail";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMergeSplitPorDetailsQueryHandler : IRequestHandler<GetMergeSplitPorDetailsQuery, PagedResponse<IReadOnlyList<MergeSplitPorDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMergeSplitPorDetailRepostiry _repository;
        public GetMergeSplitPorDetailsQueryHandler(IMapper mapper,
            IMergeSplitPorDetailRepostiry repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MergeSplitPorDetailModel>>> Handle(GetMergeSplitPorDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MergeSplitPorDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<MergeSplitPorDetailParameter, MergeSplitPorDetailModel>(validFilter);
        }
    }
}
