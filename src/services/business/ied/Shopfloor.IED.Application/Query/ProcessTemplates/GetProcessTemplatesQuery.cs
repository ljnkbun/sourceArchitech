using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.ProcessTemplates;
using Shopfloor.IED.Application.Parameters.ProcessTemplates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.ProcessTemplates
{
    public class GetProcessTemplatesQuery : IRequest<PagedResponse<IReadOnlyList<ProcessTemplateModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProcessTemplates";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProcessTemplatesQueryHandler : IRequestHandler<GetProcessTemplatesQuery, PagedResponse<IReadOnlyList<ProcessTemplateModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessTemplateRepository _repository;
        public GetProcessTemplatesQueryHandler(IMapper mapper,
            IProcessTemplateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProcessTemplateModel>>> Handle(GetProcessTemplatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProcessTemplateParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ProcessTemplateParameter.Code), nameof(ProcessTemplateParameter.Name), nameof(ProcessTemplateParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ProcessTemplateParameter, ProcessTemplateModel>(validFilter);
        }
    }
}
