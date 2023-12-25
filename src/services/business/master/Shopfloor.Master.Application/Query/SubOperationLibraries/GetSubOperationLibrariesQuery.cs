using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.SubOperationLibraries;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.SubOperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubOperationLibraries
{
    public class GetSubOperationLibrariesQuery : IRequest<PagedResponse<IReadOnlyList<SubOperationLibraryModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? OperationLibraryId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SubOperationLibraries";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSubOperationLibrarysQueryHandler : IRequestHandler<GetSubOperationLibrariesQuery, PagedResponse<IReadOnlyList<SubOperationLibraryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISubOperationLibraryRepository _repository;
        public GetSubOperationLibrarysQueryHandler(IMapper mapper,
            ISubOperationLibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SubOperationLibraryModel>>> Handle(GetSubOperationLibrariesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SubOperationLibraryParameter>(request);
            validFilter.SetSearchProps(new string[]
            {
                nameof(SubOperationLibraryParameter.Code),
                nameof(SubOperationLibraryParameter.Name),
                nameof(SubOperationLibraryParameter.OperationLibraryId)
            }.ToList()); return await _repository.GetModelPagedReponseAsync<SubOperationLibraryParameter, SubOperationLibraryModel>(validFilter);
        }
    }
}
