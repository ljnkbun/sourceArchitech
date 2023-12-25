using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingBackgrounStyles;
using Shopfloor.IED.Application.Parameters.WeavingBackgrounStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBackgrounStyles
{
    public class GetWeavingBackgrounStylesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingBackgrounStyleModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"WeavingBackgrounStyles";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingBackgrounStylesQueryHandler : IRequestHandler<GetWeavingBackgrounStylesQuery, PagedResponse<IReadOnlyList<WeavingBackgrounStyleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBackgrounStyleRepository _repository;
        public GetWeavingBackgrounStylesQueryHandler(IMapper mapper,
            IWeavingBackgrounStyleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingBackgrounStyleModel>>> Handle(GetWeavingBackgrounStylesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingBackgrounStyleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingBackgrounStyleParameter, WeavingBackgrounStyleModel>(validFilter);
        }
    }
}
