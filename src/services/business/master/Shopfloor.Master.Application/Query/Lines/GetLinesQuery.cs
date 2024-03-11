using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Lines;
using Shopfloor.Master.Application.Parameters.Lines;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Lines
{
    public class GetLinesQuery : IRequest<PagedResponse<IReadOnlyList<LineModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Lines";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLinesQueryHandler : IRequestHandler<GetLinesQuery, PagedResponse<IReadOnlyList<LineModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILineRepository _repository;
        public GetLinesQueryHandler(IMapper mapper,
            ILineRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LineModel>>> Handle(GetLinesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LineParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(LineParameter.Code), nameof(LineParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<LineParameter, LineModel>(validFilter);
        }
    }
}
