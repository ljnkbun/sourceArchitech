using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.UOMConversions;
using Shopfloor.Master.Application.Parameters.UOMConversions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.UOMConversions
{
    public class GetUOMConversionsQuery : IRequest<PagedResponse<IReadOnlyList<UOMConversionModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FromUOMId { get; set; }
        public int? ToUOMId { get; set; }
        public decimal? Value { get; set; }
        public string Action { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"UOMConversions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetUOMConversionsQueryHandler : IRequestHandler<GetUOMConversionsQuery, PagedResponse<IReadOnlyList<UOMConversionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUOMConversionRepository _repository;
        public GetUOMConversionsQueryHandler(IMapper mapper,
            IUOMConversionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<UOMConversionModel>>> Handle(GetUOMConversionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<UOMConversionParameter>(request);
            validFilter.SetSearchProps
                (new string[]
                {
                    nameof(UOMConversionParameter.FromUOMId),
                    nameof(UOMConversionParameter.ToUOMId),
                    nameof(UOMConversionParameter.Value),
                    nameof(UOMConversionParameter.Action)
                }.ToList());
            return await _repository.GetModelPagedReponseAsync<UOMConversionParameter, UOMConversionModel>(validFilter);
        }
    }
}
