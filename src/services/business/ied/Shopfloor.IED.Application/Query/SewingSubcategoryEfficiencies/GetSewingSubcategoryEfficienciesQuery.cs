using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencies
{
    public class GetSewingSubcategoryEfficienciesQuery : IRequest<PagedResponse<IReadOnlyList<SewingSubcategoryEfficiencyModel>>>, ICacheableMediatrQuery
    {
        public int? SewingEfficiencyProfileId { get; set; }

        public string SubCategory { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingSubcategoryEfficiencies";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetSewingSubcategoryEfficienciesQueryHandler : IRequestHandler<GetSewingSubcategoryEfficienciesQuery, PagedResponse<IReadOnlyList<SewingSubcategoryEfficiencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubcategoryEfficiencyRepository _repository;

        public GetSewingSubcategoryEfficienciesQueryHandler(IMapper mapper,
            ISewingSubcategoryEfficiencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingSubcategoryEfficiencyModel>>> Handle(GetSewingSubcategoryEfficienciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingSubcategoryEfficiencyParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingSubcategoryEfficiencyParameter, SewingSubcategoryEfficiencyModel>(validFilter);
        }
    }
}