using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Application.Parameters.PORDetails;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.PORDetails
{
    public class GetPORDetailsQuery : IRequest<PagedResponse<IReadOnlyList<PORDetailModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? PORId { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? Type { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"PORDetails";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPORDetailsQueryHandler : IRequestHandler<GetPORDetailsQuery, PagedResponse<IReadOnlyList<PORDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPORDetailRepository _repository;
        public GetPORDetailsQueryHandler(IMapper mapper, IPORDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<PagedResponse<IReadOnlyList<PORDetailModel>>> Handle(GetPORDetailsQuery query, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PORDetailParameter>(query);
            return await _repository.GetModelPagedReponseAsync<PORDetailParameter, PORDetailModel>(validFilter);
        }
    }
}
