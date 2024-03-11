using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.AQLVersions;
using Shopfloor.Inspection.Application.Parameters.AQLVersions;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.AQLVersions
{
    public class GetAQLVersionsQuery : IRequest<PagedResponse<IReadOnlyList<AQLVersionModel>>>
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
    }
    public class GetAQLVersionsQueryHandler : IRequestHandler<GetAQLVersionsQuery, PagedResponse<IReadOnlyList<AQLVersionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAQLVersionRepository _repository;
        public GetAQLVersionsQueryHandler(IMapper mapper,
            IAQLVersionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<AQLVersionModel>>> Handle(GetAQLVersionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<AQLVersionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(AQLVersionParameter.Code), nameof(AQLVersionParameter.Name) }.ToList());
            return await _repository.GetModelSingleQueryPagedReponseAsync<AQLVersionParameter, AQLVersionModel>(validFilter);
        }
    }
}
