using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DCTemplates;
using Shopfloor.IED.Application.Parameters.DCTemplates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplates
{
    public class GetDCTemplatesQuery : IRequest<PagedResponse<IReadOnlyList<DCTemplateModel>>>, ICacheableMediatrQuery
    {
        public string Code { get; set; }
        public string Name { get; set; }

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
        public string CacheKey => $"DCTemplates";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDCTemplatesQueryHandler : IRequestHandler<GetDCTemplatesQuery, PagedResponse<IReadOnlyList<DCTemplateModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateRepository _repository;

        public GetDCTemplatesQueryHandler(IMapper mapper,
            IDCTemplateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DCTemplateModel>>> Handle(GetDCTemplatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DCTemplateParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DCTemplateParameter, DCTemplateModel>(validFilter);
        }
    }
}