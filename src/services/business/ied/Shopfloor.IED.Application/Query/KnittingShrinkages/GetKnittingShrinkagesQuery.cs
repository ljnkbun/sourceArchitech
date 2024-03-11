using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingShrinkages;
using Shopfloor.IED.Application.Parameters.KnittingShrinkages;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingShrinkages
{
    public class GetKnittingShrinkagesQuery : IRequest<PagedResponse<IReadOnlyList<KnittingShrinkageModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"KnittingShrinkages";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetKnittingShrinkagesQueryHandler : IRequestHandler<GetKnittingShrinkagesQuery, PagedResponse<IReadOnlyList<KnittingShrinkageModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingShrinkageRepository _repository;
        public GetKnittingShrinkagesQueryHandler(IMapper mapper,
            IKnittingShrinkageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingShrinkageModel>>> Handle(GetKnittingShrinkagesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingShrinkageParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingShrinkageParameter, KnittingShrinkageModel>(validFilter);
        }
    }
}
