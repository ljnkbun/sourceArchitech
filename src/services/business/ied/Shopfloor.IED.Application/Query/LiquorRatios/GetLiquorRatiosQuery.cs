using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.LiquorRatios;
using Shopfloor.IED.Application.Parameters.LiquorRatios;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.LiquorRatios
{
    public class GetLiquorRatiosQuery : IRequest<PagedResponse<IReadOnlyList<LiquorRatioModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal? Value { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"LiquorRatios";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLiquorRatiosQueryHandler : IRequestHandler<GetLiquorRatiosQuery, PagedResponse<IReadOnlyList<LiquorRatioModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILiquorRatioRepository _repository;
        public GetLiquorRatiosQueryHandler(IMapper mapper,
            ILiquorRatioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LiquorRatioModel>>> Handle(GetLiquorRatiosQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LiquorRatioParameter>(request);
            return await _repository.GetModelPagedReponseAsync<LiquorRatioParameter, LiquorRatioModel>(validFilter);
        }
    }
}
