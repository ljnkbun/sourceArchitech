using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Genders;
using Shopfloor.Master.Application.Parameters.FiberTypes;
using Shopfloor.Master.Application.Parameters.Genders;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Genders
{
    public class GetGendersQuery : IRequest<PagedResponse<IReadOnlyList<GenderModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Genders";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, PagedResponse<IReadOnlyList<GenderModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _repository;
        public GetGendersQueryHandler(IMapper mapper,
            IGenderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GenderModel>>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GenderParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(GenderParameter.Code), nameof(GenderParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<GenderParameter, GenderModel>(validFilter);
        }
    }
}
