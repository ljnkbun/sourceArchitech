using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.AccountGroups;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.AccountGroups
{
    public class GetAccountGroupsQuery : IRequest<PagedResponse<IReadOnlyList<AccountGroupModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"AccountGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetAccountGroupsQueryHandler : IRequestHandler<GetAccountGroupsQuery, PagedResponse<IReadOnlyList<AccountGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountGroupRepository _repository;
        public GetAccountGroupsQueryHandler(IMapper mapper,
            IAccountGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<AccountGroupModel>>> Handle(GetAccountGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<AccountGroupParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(AccountGroupParameter.Code), nameof(AccountGroupParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<AccountGroupParameter, AccountGroupModel>(validFilter);
        }
    }
}
