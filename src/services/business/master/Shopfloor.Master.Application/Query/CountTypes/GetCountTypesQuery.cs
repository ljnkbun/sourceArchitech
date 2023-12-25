using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.CountTypes;
using Shopfloor.Master.Application.Parameters.Countries;
using Shopfloor.Master.Application.Parameters.CountTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CountTypes
{
    public class GetCountTypesQuery : IRequest<PagedResponse<IReadOnlyList<CountTypeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"CountTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCountTypesQueryHandler : IRequestHandler<GetCountTypesQuery, PagedResponse<IReadOnlyList<CountTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICountTypeRepository _repository;
        public GetCountTypesQueryHandler(IMapper mapper,
            ICountTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CountTypeModel>>> Handle(GetCountTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CountTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CountTypeParameter.Code), nameof(CountTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CountTypeParameter, CountTypeModel>(validFilter);
        }
    }
}
