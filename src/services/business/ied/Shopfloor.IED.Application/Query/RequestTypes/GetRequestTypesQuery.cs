using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestTypes;
using Shopfloor.IED.Application.Parameters.RequestTypes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestTypes
{
    public class GetRequestTypesQuery : IRequest<PagedResponse<IReadOnlyList<RequestTypeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"RequestTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRequestTypesQueryHandler : IRequestHandler<GetRequestTypesQuery, PagedResponse<IReadOnlyList<RequestTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestTypeRepository _repository;
        public GetRequestTypesQueryHandler(IMapper mapper,
            IRequestTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestTypeModel>>> Handle(GetRequestTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestTypeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestTypeParameter, RequestTypeModel>(validFilter);
        }
    }
}
