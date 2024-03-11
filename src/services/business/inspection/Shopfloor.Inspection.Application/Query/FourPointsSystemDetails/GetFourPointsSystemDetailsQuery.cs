using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.FourPointsSystemDetails;
using Shopfloor.Inspection.Application.Parameters.FourPointsSystemDetails;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.FourPointsSystemDetails
{
    public class GetFourPointsSystemDetailsQuery : IRequest<PagedResponse<IReadOnlyList<FourPointsSystemDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType? GradeType { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"FourPointsSystemDetail";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFourPointsSystemDetailsQueryHandler : IRequestHandler<GetFourPointsSystemDetailsQuery, PagedResponse<IReadOnlyList<FourPointsSystemDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFourPointsSystemDetailRepository _repository;
        public GetFourPointsSystemDetailsQueryHandler(IMapper mapper,
            IFourPointsSystemDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FourPointsSystemDetailModel>>> Handle(GetFourPointsSystemDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FourPointsSystemDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<FourPointsSystemDetailParameter, FourPointsSystemDetailModel>(validFilter);
        }
    }
}
