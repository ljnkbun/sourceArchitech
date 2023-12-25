using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Twists;
using Shopfloor.Master.Application.Parameters.SupplierTypes;
using Shopfloor.Master.Application.Parameters.Twists;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Twists
{
    public class GetTwistsQuery : IRequest<PagedResponse<IReadOnlyList<TwistModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Twists";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetTwistsQueryHandler : IRequestHandler<GetTwistsQuery, PagedResponse<IReadOnlyList<TwistModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ITwistRepository _repository;
        public GetTwistsQueryHandler(IMapper mapper,
            ITwistRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<TwistModel>>> Handle(GetTwistsQuery request, CancellationToken cancellationToken)
        {

            var validFilter = _mapper.Map<TwistParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(TwistParameter.Code), nameof(TwistParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<TwistParameter, TwistModel>(validFilter);
        }
    }
}
