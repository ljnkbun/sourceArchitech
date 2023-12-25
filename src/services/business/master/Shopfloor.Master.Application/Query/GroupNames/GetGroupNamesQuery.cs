using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.GroupNames;
using Shopfloor.Master.Application.Parameters.GroupNames;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.GroupNames
{
    public class GetGroupNamesQuery : IRequest<PagedResponse<IReadOnlyList<GroupNameModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"GroupNames";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetGroupNamesQueryHandler : IRequestHandler<GetGroupNamesQuery, PagedResponse<IReadOnlyList<GroupNameModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IGroupNameRepository _repository;
        public GetGroupNamesQueryHandler(IMapper mapper,
            IGroupNameRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GroupNameModel>>> Handle(GetGroupNamesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GroupNameParameter>(request);
            return await _repository.GetModelPagedReponseAsync<GroupNameParameter, GroupNameModel>(validFilter);
        }
    }
}
