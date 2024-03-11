using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystems;
using Shopfloor.Inspection.Application.Parameters.OneHundredPointSystems;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.OneHundredPointSystems
{
    public class GetOneHundredPointSystemsQuery : IRequest<PagedResponse<IReadOnlyList<OneHundredPointSystemModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"OneHundredPointSystem";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetOneHundredPointSystemsQueryHandler : IRequestHandler<GetOneHundredPointSystemsQuery, PagedResponse<IReadOnlyList<OneHundredPointSystemModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IOneHundredPointSystemRepository _repository;
        public GetOneHundredPointSystemsQueryHandler(IMapper mapper,
            IOneHundredPointSystemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<OneHundredPointSystemModel>>> Handle(GetOneHundredPointSystemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<OneHundredPointSystemParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(OneHundredPointSystemParameter.Code), nameof(OneHundredPointSystemParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<OneHundredPointSystemParameter, OneHundredPointSystemModel>(validFilter);
        }
    }
}
