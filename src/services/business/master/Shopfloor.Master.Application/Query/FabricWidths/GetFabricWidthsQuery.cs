using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.FabricWidths;
using Shopfloor.Master.Application.Parameters.Divisions;
using Shopfloor.Master.Application.Parameters.FabricWidths;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FabricWidths
{
    public class GetFabricWidthsQuery : IRequest<PagedResponse<IReadOnlyList<FabricWidthModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"FabricWidths";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFabricWidthsQueryHandler : IRequestHandler<GetFabricWidthsQuery, PagedResponse<IReadOnlyList<FabricWidthModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricWidthRepository _repository;
        public GetFabricWidthsQueryHandler(IMapper mapper,
            IFabricWidthRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FabricWidthModel>>> Handle(GetFabricWidthsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FabricWidthParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FabricWidthParameter.Code), nameof(FabricWidthParameter.Name), nameof(FabricWidthParameter.Inseam) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FabricWidthParameter, FabricWidthModel>(validFilter);
        }
    }
}
