using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.OperationLibraries;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.OperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.OperationLibraries
{
    public class GetOperationLibrariesQuery : IRequest<PagedResponse<IReadOnlyList<OperationLibraryModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProcessLibraryId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"OperationLibraries";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetOperationLibrarysQueryHandler : IRequestHandler<GetOperationLibrariesQuery, PagedResponse<IReadOnlyList<OperationLibraryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IOperationLibraryRepository _repository;
        public GetOperationLibrarysQueryHandler(IMapper mapper,
            IOperationLibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<OperationLibraryModel>>> Handle(GetOperationLibrariesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<OperationLibraryParameter>(request);
            validFilter.SetSearchProps(new string[] 
                { 
                    nameof(OperationLibraryParameter.Code), 
                    nameof(OperationLibraryParameter.Name),
                    nameof(OperationLibraryParameter.ProcessLibraryId)
                }.ToList());
            return await _repository.GetModelPagedReponseAsync<OperationLibraryParameter, OperationLibraryModel>(validFilter);
        }
    }
}
