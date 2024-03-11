using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.CriticalParts;
using Shopfloor.Planning.Application.Parameters.CriticalParts;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.CriticalParts
{
    public class GetCriticalPartsQuery : IRequest<PagedResponse<IReadOnlyList<CriticalPartModel>>>
    {
		public int? PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int? Priority { get; set; }

		public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWfxCriticalPartsQueryHandler : IRequestHandler<GetCriticalPartsQuery, PagedResponse<IReadOnlyList<CriticalPartModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICriticalPartRepository _response;
        public GetWfxCriticalPartsQueryHandler(IMapper mapper
            , ICriticalPartRepository response)
        {
            _mapper = mapper;
            _response = response;
        }

        public async Task<PagedResponse<IReadOnlyList<CriticalPartModel>>> Handle(GetCriticalPartsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CriticalPartParameter>(request);
            return await _response.GetModelPagedReponseAsync<CriticalPartParameter, CriticalPartModel>(validFilter);
        }
    }
}