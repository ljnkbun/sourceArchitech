using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.AQLs;
using Shopfloor.Inspection.Application.Parameters.AQLs;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.AQLs
{
    public class GetAQLsQuery : IRequest<PagedResponse<IReadOnlyList<AQLModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? AQLVersionId { get; set; }
		public int? LotSizeFrom { get; set; }
		public int? LotSizeTo { get; set; }
		public int? SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetAQLsQueryHandler : IRequestHandler<GetAQLsQuery, PagedResponse<IReadOnlyList<AQLModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAQLRepository _repository;
        public GetAQLsQueryHandler(IMapper mapper,
            IAQLRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<AQLModel>>> Handle(GetAQLsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<AQLParameter>(request);
            return await _repository.GetModelPagedReponseAsync<AQLParameter, AQLModel>(validFilter);
        }
    }
}
