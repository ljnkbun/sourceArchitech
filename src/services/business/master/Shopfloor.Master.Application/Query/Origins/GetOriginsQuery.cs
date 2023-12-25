using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Origins;
using Shopfloor.Master.Application.Parameters.Micronaires;
using Shopfloor.Master.Application.Parameters.Origins;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Origins
{
    public class GetOriginsQuery : IRequest<PagedResponse<IReadOnlyList<OriginModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Origins";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetOriginsQueryHandler : IRequestHandler<GetOriginsQuery, PagedResponse<IReadOnlyList<OriginModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IOriginRepository _repository;
        public GetOriginsQueryHandler(IMapper mapper,
            IOriginRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<OriginModel>>> Handle(GetOriginsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<OriginParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(OriginParameter.Code), nameof(OriginParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<OriginParameter, OriginModel>(validFilter);
        }
    }
}
