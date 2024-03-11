using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRappoMatrics;
using Shopfloor.IED.Application.Parameters.WeavingRappoMatrics;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappoMatrics
{
    public class GetWeavingRappoMatricsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingRappoMatricModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingRappoId { get; set; }
        public int? SlotIndex { get; set; }
        public int? RowIndex { get; set; }
        public int? ColumnIndex { get; set; }
        public int? LoopIndex { get; set; }
        public int? HorizontalYarnId { get; set; }
        public int? VerticleYarnId { get; set; }
        public int? BackgroundType { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWeavingRappoMatricsQueryHandler : IRequestHandler<GetWeavingRappoMatricsQuery, PagedResponse<IReadOnlyList<WeavingRappoMatricModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoMatricRepository _repository;
        public GetWeavingRappoMatricsQueryHandler(IMapper mapper,
            IWeavingRappoMatricRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingRappoMatricModel>>> Handle(GetWeavingRappoMatricsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingRappoMatricParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingRappoMatricParameter, WeavingRappoMatricModel>(validFilter);
        }
    }
}
