using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Micronaires;
using Shopfloor.Master.Application.Parameters.Grades;
using Shopfloor.Master.Application.Parameters.Micronaires;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Micronaires
{
    public class GetMicronairesQuery : IRequest<PagedResponse<IReadOnlyList<MicronaireModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Micronaires";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMicronairesQueryHandler : IRequestHandler<GetMicronairesQuery, PagedResponse<IReadOnlyList<MicronaireModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMicronaireRepository _repository;
        public GetMicronairesQueryHandler(IMapper mapper,
            IMicronaireRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MicronaireModel>>> Handle(GetMicronairesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MicronaireParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(MicronaireParameter.Code), nameof(MicronaireParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<MicronaireParameter, MicronaireModel>(validFilter);
        }
    }
}
