using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Divisions;
using Shopfloor.Master.Application.Parameters.Currencies;
using Shopfloor.Master.Application.Parameters.Divisions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Divisions
{
    public class GetDivisionsQuery : IRequest<PagedResponse<IReadOnlyList<DivisionModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Divisions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetDivisionsQueryHandler : IRequestHandler<GetDivisionsQuery, PagedResponse<IReadOnlyList<DivisionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDivisionRepository _repository;
        public GetDivisionsQueryHandler(IMapper mapper,
            IDivisionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DivisionModel>>> Handle(GetDivisionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DivisionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(DivisionParameter.Code), nameof(DivisionParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<DivisionParameter, DivisionModel>(validFilter);
        }
    }
}
