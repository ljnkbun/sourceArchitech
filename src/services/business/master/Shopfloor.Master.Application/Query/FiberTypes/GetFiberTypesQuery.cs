using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.FiberTypes;
using Shopfloor.Master.Application.Parameters.Divisions;
using Shopfloor.Master.Application.Parameters.FiberTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FiberTypes
{
    public class GetFiberTypesQuery : IRequest<PagedResponse<IReadOnlyList<FiberTypeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"FiberTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFiberTypesQueryHandler : IRequestHandler<GetFiberTypesQuery, PagedResponse<IReadOnlyList<FiberTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFiberTypeRepository _repository;
        public GetFiberTypesQueryHandler(IMapper mapper,
            IFiberTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FiberTypeModel>>> Handle(GetFiberTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FiberTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FiberTypeParameter.Code), nameof(FiberTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FiberTypeParameter, FiberTypeModel>(validFilter);
        }
    }
}
