using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.FourPointsSystems;
using Shopfloor.Inspection.Application.Parameters.FourPointsSystems;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.FourPointsSystems
{
    public class GetFourPointsSystemsQuery : IRequest<PagedResponse<IReadOnlyList<FourPointsSystemModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProductGroup { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"FourPointsSystem";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFourPointsSystemsQueryHandler : IRequestHandler<GetFourPointsSystemsQuery, PagedResponse<IReadOnlyList<FourPointsSystemModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFourPointsSystemRepository _repository;
        public GetFourPointsSystemsQueryHandler(IMapper mapper,
            IFourPointsSystemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FourPointsSystemModel>>> Handle(GetFourPointsSystemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FourPointsSystemParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FourPointsSystemParameter.Code), nameof(FourPointsSystemParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FourPointsSystemParameter, FourPointsSystemModel>(validFilter);
        }
    }
}
