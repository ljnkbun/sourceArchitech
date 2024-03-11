using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DCTemplateDetails;
using Shopfloor.IED.Application.Parameters.DCTemplateDetails;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplateDetails
{
    public class GetDCTemplateDetailsQuery : IRequest<PagedResponse<IReadOnlyList<DCTemplateDetailModel>>>
    {
        public int? DCTemplateTaskId { get; set; }
        public int? ChemicalId { get; set; }
        public string ChemicalSubCategory { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal? Value { get; set; }

        public int? LineNumber { get; set; }

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
        public string CacheKey => $"DCTemplateDetails";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDCTemplateDetailsQueryHandler : IRequestHandler<GetDCTemplateDetailsQuery, PagedResponse<IReadOnlyList<DCTemplateDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateDetailRepository _repository;

        public GetDCTemplateDetailsQueryHandler(IMapper mapper,
            IDCTemplateDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DCTemplateDetailModel>>> Handle(GetDCTemplateDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DCTemplateDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DCTemplateDetailParameter, DCTemplateDetailModel>(validFilter);
        }
    }
}