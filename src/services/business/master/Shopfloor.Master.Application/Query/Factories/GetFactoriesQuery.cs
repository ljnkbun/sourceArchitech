using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Factories;
using Shopfloor.Master.Application.Parameters.Factories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Factories
{
    public class GetFactoriesQuery : IRequest<PagedResponse<IReadOnlyList<FactoryModel>>>, ICacheableMediatrQuery
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }

        #region default
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Factories";
        public TimeSpan? SlidingExpiration { get; set; }
        #endregion

    }
    public class GetFactoriesQueryHandler : IRequestHandler<GetFactoriesQuery, PagedResponse<IReadOnlyList<FactoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFactoryRepository _repository;
        public GetFactoriesQueryHandler(IMapper mapper,
            IFactoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FactoryModel>>> Handle(GetFactoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FactoryParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FactoryParameter.Code), nameof(FactoryParameter.Name) }.ToList());
            return await _repository.GetModelSingleQueryPagedReponseAsync<FactoryParameter, FactoryModel>(validFilter);
        }
    }
}
