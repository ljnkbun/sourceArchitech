using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatures;
using Shopfloor.IED.Application.Parameters.SewingFeatures;
using Shopfloor.IED.Application.Parameters.SewingOperationLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFeatures
{
    public class GetSewingFeaturesQuery : IRequest<PagedResponse<IReadOnlyList<SewingFeatureModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal? LabourCost { get; set; }
        public decimal? AllowedTime { get; set; }
        public decimal? TotalSMV { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingFeatures";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingFeaturesQueryHandler : IRequestHandler<GetSewingFeaturesQuery, PagedResponse<IReadOnlyList<SewingFeatureModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFeatureRepository _repository;
        public GetSewingFeaturesQueryHandler(IMapper mapper,
            ISewingFeatureRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingFeatureModel>>> Handle(GetSewingFeaturesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingFeatureParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingOperationLibParameter.Code), nameof(SewingOperationLibParameter.Name), nameof(SewingOperationLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingFeatureParameter, SewingFeatureModel>(validFilter);
        }
    }
}
