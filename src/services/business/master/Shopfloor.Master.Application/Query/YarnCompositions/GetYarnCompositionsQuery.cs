using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.YarnCompositions;
using Shopfloor.Master.Application.Parameters.YarnCompositions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.YarnCompositions
{
    public class GetYarnCompositionsQuery : IRequest<PagedResponse<IReadOnlyList<YarnCompositionModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"YarnCompositions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetYarnCompositionsQueryHandler : IRequestHandler<GetYarnCompositionsQuery, PagedResponse<IReadOnlyList<YarnCompositionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IYarnCompositionRepository _repository;
        public GetYarnCompositionsQueryHandler(IMapper mapper,
            IYarnCompositionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<YarnCompositionModel>>> Handle(GetYarnCompositionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<YarnCompositionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(YarnCompositionParameter.Code), nameof(YarnCompositionParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<YarnCompositionParameter, YarnCompositionModel>(validFilter);
        }
    }
}
