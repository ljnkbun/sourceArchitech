using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingComponentGroups;
using Shopfloor.IED.Application.Parameters.SewingComponentGroups;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingComponentGroups
{
    public class GetSewingComponentGroupsQuery : IRequest<PagedResponse<IReadOnlyList<SewingComponentGroupModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"SewingComponentGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingComponentGroupsQueryHandler : IRequestHandler<GetSewingComponentGroupsQuery, PagedResponse<IReadOnlyList<SewingComponentGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingComponentGroupRepository _repository;
        public GetSewingComponentGroupsQueryHandler(IMapper mapper,
            ISewingComponentGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingComponentGroupModel>>> Handle(GetSewingComponentGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingComponentGroupParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingComponentGroupParameter, SewingComponentGroupModel>(validFilter);
        }
    }
}
