using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Structures;
using Shopfloor.Master.Application.Parameters.Staples;
using Shopfloor.Master.Application.Parameters.Structures;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Structures
{
    public class GetStructuresQuery : IRequest<PagedResponse<IReadOnlyList<StructureModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Structures";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetStructuresQueryHandler : IRequestHandler<GetStructuresQuery, PagedResponse<IReadOnlyList<StructureModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStructureRepository _repository;
        public GetStructuresQueryHandler(IMapper mapper,
            IStructureRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StructureModel>>> Handle(GetStructuresQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StructureParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(StructureParameter.Code), nameof(StructureParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<StructureParameter, StructureModel>(validFilter);
        }
    }
}
