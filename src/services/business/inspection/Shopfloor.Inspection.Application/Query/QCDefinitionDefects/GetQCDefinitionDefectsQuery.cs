using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.QCDefinitionDefects;
using Shopfloor.Inspection.Application.Parameters.QCDefinitionDefects;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefinitionDefects
{
    public class GetQCDefinitionDefectsQuery : IRequest<PagedResponse<IReadOnlyList<QCDefinitionDefectModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? QCDefinitionId { get; set; }
		public int? QCDefectId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"QCDefinitionDefects";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetQCDefinitionDefectsQueryHandler : IRequestHandler<GetQCDefinitionDefectsQuery, PagedResponse<IReadOnlyList<QCDefinitionDefectModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefinitionDefectRepository _repository;
        public GetQCDefinitionDefectsQueryHandler(IMapper mapper,
            IQCDefinitionDefectRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCDefinitionDefectModel>>> Handle(GetQCDefinitionDefectsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCDefinitionDefectParameter>(request);
            return await _repository.GetModelPagedReponseAsync<QCDefinitionDefectParameter, QCDefinitionDefectModel>(validFilter);
        }
    }
}
