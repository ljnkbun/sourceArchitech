using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Constructions;
using Shopfloor.Master.Application.Parameters.CompanyCurrencies;
using Shopfloor.Master.Application.Parameters.Constructions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Constructions
{
    public class GetConstructionsQuery : IRequest<PagedResponse<IReadOnlyList<ConstructionModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Constructions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetConstructionsQueryHandler : IRequestHandler<GetConstructionsQuery, PagedResponse<IReadOnlyList<ConstructionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IConstructionRepository _repository;
        public GetConstructionsQueryHandler(IMapper mapper,
            IConstructionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ConstructionModel>>> Handle(GetConstructionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ConstructionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ConstructionParameter.Code), nameof(ConstructionParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ConstructionParameter, ConstructionModel>(validFilter);
        }
    }
}
