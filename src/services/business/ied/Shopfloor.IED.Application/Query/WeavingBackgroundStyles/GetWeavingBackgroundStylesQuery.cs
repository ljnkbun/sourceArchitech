using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingBackgroundStyles;
using Shopfloor.IED.Application.Parameters.WeavingBackgroundStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBackgroundStyles
{
    public class GetWeavingBackgroundStylesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingBackgroundStyleModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"WeavingBackgroundStyles";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingBackgroundStylesQueryHandler : IRequestHandler<GetWeavingBackgroundStylesQuery, PagedResponse<IReadOnlyList<WeavingBackgroundStyleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBackgroundStyleRepository _repository;
        public GetWeavingBackgroundStylesQueryHandler(IMapper mapper,
            IWeavingBackgroundStyleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingBackgroundStyleModel>>> Handle(GetWeavingBackgroundStylesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingBackgroundStyleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingBackgroundStyleParameter, WeavingBackgroundStyleModel>(validFilter);
        }
    }
}
