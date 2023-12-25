using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DCTemplateTasks;
using Shopfloor.IED.Application.Parameters.DCTemplateTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplateTasks
{
    public class GetDCTemplateTasksQuery : IRequest<PagedResponse<IReadOnlyList<DCTemplateTaskModel>>>, ICacheableMediatrQuery
    {
        public int? DCTemplateId { get; set; }
        public int? TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string Temperature { get; set; }
        public int? Minute { get; set; }

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
        public string CacheKey => $"DCTemplateTasks";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDCTemplateTasksQueryHandler : IRequestHandler<GetDCTemplateTasksQuery, PagedResponse<IReadOnlyList<DCTemplateTaskModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateTaskRepository _repository;

        public GetDCTemplateTasksQueryHandler(IMapper mapper,
            IDCTemplateTaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DCTemplateTaskModel>>> Handle(GetDCTemplateTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DCTemplateTaskParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DCTemplateTaskParameter, DCTemplateTaskModel>(validFilter);
        }
    }
}