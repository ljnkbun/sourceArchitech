using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.FabricContents;
using Shopfloor.Master.Application.Parameters.Divisions;
using Shopfloor.Master.Application.Parameters.FabricContents;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FabricContents
{
    public class GetFabricContentsQuery : IRequest<PagedResponse<IReadOnlyList<FabricContentModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"FabricContents";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFabricContentsQueryHandler : IRequestHandler<GetFabricContentsQuery, PagedResponse<IReadOnlyList<FabricContentModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricContentRepository _repository;
        public GetFabricContentsQueryHandler(IMapper mapper,
            IFabricContentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FabricContentModel>>> Handle(GetFabricContentsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FabricContentParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FabricContentParameter.Code), nameof(FabricContentParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FabricContentParameter, FabricContentModel>(validFilter);
        }
    }
}
