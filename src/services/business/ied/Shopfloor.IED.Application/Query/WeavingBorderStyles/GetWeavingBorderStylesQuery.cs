using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingBorderStyles;
using Shopfloor.IED.Application.Parameters.WeavingBorderStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBorderStyles
{
    public class GetWeavingBorderStylesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingBorderStyleModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"WeavingBorderStyles";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingBorderStylesQueryHandler : IRequestHandler<GetWeavingBorderStylesQuery, PagedResponse<IReadOnlyList<WeavingBorderStyleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBorderStyleRepository _repository;
        public GetWeavingBorderStylesQueryHandler(IMapper mapper,
            IWeavingBorderStyleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingBorderStyleModel>>> Handle(GetWeavingBorderStylesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingBorderStyleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingBorderStyleParameter, WeavingBorderStyleModel>(validFilter);
        }
    }
}
